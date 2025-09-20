# Global Variables
$configPath = Join-Path $PSScriptRoot ".." "config" "config.json"
$config = Get-Content $configPath -Raw | ConvertFrom-Json
$API_URL = "https://leetcode.com/api/problems/all/"
$cacheFile = Join-Path $PSScriptRoot ".." "cache" "problems.json"

#region Helper Functions

function Get-PaddedProblemId {
    param([string]$problemNumber)
    
    $paddingLength = $config.problemIdPadding ?? 4  # Default to 4 digits
    return $problemNumber.PadLeft($paddingLength, '0')
}

function Build-ProblemFolderName {
    param([string]$problemNumber, [string]$titleSlug)

    $paddedId = Get-PaddedProblemId -problemNumber $problemNumber
    return "$paddedId-$titleSlug"
}

function Find-ProblemFolder {
    param([string]$problemNumber, [string]$language)

    $languagePath = $config.problemPath.$language
    if (-not (Test-Path $languagePath)) {
        Write-Host "[ERROR] Language path $languagePath does not exist." -ForegroundColor Red
        return $null
    }

    $paddedId = Get-PaddedProblemId -problemNumber $problemNumber
    $pattern = "$paddedId-*"
    
    $matchingFolders = Get-ChildItem -Path $languagePath -Directory | Where-Object { $_.Name -like $pattern }
    
    if ($matchingFolders.Count -eq 0) {
        Write-Host "[ERROR] No problem folder found for problem number $problemNumber in $language." -ForegroundColor Red
        return $null
    }
    elseif ($matchingFolders.Count -gt 1) {
        Write-Host "[WARNING] Multiple folders found for problem $problemNumber. Using first match: $($matchingFolders[0].Name)" -ForegroundColor Yellow
    }
    
    return $matchingFolders[0].FullName
}

function Remove-ProblemFolder {
    param([string]$folderPath)

    if (-not (Test-Path $folderPath)) {
        Write-Host "[ERROR] Problem folder $folderPath does not exist." -ForegroundColor Red
        return $false
    }

    try {
        Remove-Item -Path $folderPath -Recurse -Force
        Write-Host "[SUCCESS] Removed problem folder: $folderPath" -ForegroundColor Green
        return $true
    }
    catch {
        Write-Host "[ERROR] Failed to remove problem folder: $($_.Exception.Message)" -ForegroundColor Red
        return $false
    }
}

function PascalCaseConverter {
    param([string]$inputString)

    $words = $inputString -split '[-_ ]'
    $pascalCase = ($words | ForEach-Object { $_.Substring(0,1).ToUpper() + $_.Substring(1).ToLower() }) -join ''
    return $pascalCase
}

#endregion

#region Cache Management Functions

function Update-ProblemCache {
    Write-Host "[WORKING] Checking problem cache..." -ForegroundColor Yellow

    # Checking if cache file exists and is recent (e.g., within the last day)
    if (Test-Path $cacheFile) {
        $fileInfo = Get-Item $cacheFile
        if ($fileInfo.LastWriteTime -gt (Get-Date).AddDays(-1)) {
            Write-Host "[INFO] Cache is up to date." -ForegroundColor Blue
            return
        }
    }
    else {
        # Ensure the cache directory exists
        $cacheDir = Split-Path $cacheFile
        if (-not (Test-Path $cacheDir)) {
            New-Item -ItemType Directory -Path $cacheDir | Out-Null
        }
    }

    # Fetching problem data from LeetCode API
    Write-Host "[WORKING] Updating problem cache..." -ForegroundColor Yellow
    try {
        $response = Invoke-RestMethod -Uri $API_URL -Method Get -TimeoutSec 30

        if ($response -and $response.stat_status_pairs) {
            $response | ConvertTo-Json -Depth 10 | Set-Content $cacheFile
            Write-Host "[SUCCESS] Cache updated successfully." -ForegroundColor Green
        }
        else {
            Write-Host "[ERROR] Invalid response structure from API" -ForegroundColor Red
            Write-Host "Response keys: $($response | Get-Member -MemberType NoteProperty | Select-Object -ExpandProperty Name)" -ForegroundColor Gray
            return 1
        }
    }
    catch {
        Write-Host "[ERROR] Failed to fetch problems from API: $($_.Exception.Message)" -ForegroundColor Red
        return 1
    }
}

function Get-ProblemDataFromCache {
    param([string]$problemNumber)

    # Use global $cacheFile variable defined at the top of the script
    if (-not (Test-Path $cacheFile)) {
        Write-Host "[ERROR] Problem cache not found. Please run the script again to update the cache." -ForegroundColor Red
        return $null
    }

    $problemsData = Get-Content $cacheFile -Raw | ConvertFrom-Json
    foreach ($item in $problemsData.stat_status_pairs) {
        if ($item.stat.frontend_question_id -eq [int]$problemNumber) {
            return $item
        }
    }

    Write-Host "[ERROR] Problem number $problemNumber not found in cache." -ForegroundColor Red
    return $null
}

#endregion

#region Language Operations

function CSharpRemovalOperations {
    param([string]$problemFolderPath, [string]$questionTitle)

    $projectName = PascalCaseConverter -input $questionTitle
    $csprojPath = Join-Path $problemFolderPath "$projectName.csproj"

    # Remove the project from the solution if it exists
    $solutionPath = Join-Path $PSScriptRoot ".." "problems" "CSharp" "LeetCode.slnx"
    
    if ((Test-Path $csprojPath) -and (Test-Path $solutionPath)) {
        try {
            Write-Host "[WORKING] Removing project from solution..." -ForegroundColor Yellow
            $result = dotnet sln $solutionPath remove $csprojPath 2>&1
            if ($LASTEXITCODE -eq 0) {
                Write-Host "[SUCCESS] Removed project from solution." -ForegroundColor Green
            }
            else {
                Write-Host "[WARNING] Project may not have been in solution or removal failed: $result" -ForegroundColor Yellow
            }
        }
        catch {
            Write-Host "[WARNING] Failed to remove project from solution: $($_.Exception.Message)" -ForegroundColor Yellow
        }
    }
    else {
        if (-not (Test-Path $csprojPath)) {
            Write-Host "[INFO] Project file not found, skipping solution removal." -ForegroundColor Blue
        }
        if (-not (Test-Path $solutionPath)) {
            Write-Host "[INFO] Solution file not found, skipping solution removal." -ForegroundColor Blue
        }
    }
}

#endregion

function Main {
    Write-Host "[WORKING] Removing problem..." -ForegroundColor Yellow
    Update-ProblemCache
    Write-Host "[SUCCESS] Problem cache is ready.`n" -ForegroundColor Green

    # Prompt user for problem number
    while ($true) {
        $problemNumber = Read-Host "Enter the LeetCode problem number to remove (or 'exit' to quit)"
        if ($problemNumber -eq 'exit') {
            Write-Host "Exiting..." -ForegroundColor Yellow
            return
        }
        if ($problemNumber -match '^\d+$') {
            break
        }
        else {
            Write-Host "[ERROR] Invalid input. Please enter a numeric problem number." -ForegroundColor Red
        }
    }

    # Prompt user for programming language
    while ($true) {
        $language = Read-Host "Enter the programming language (e.g., 'csharp')"
        if ($language) {
            $languageFound = $false
            foreach ($lang in $config.supportedLanguages) {
                if ($language.ToLower() -eq $lang.ToLower()) {
                    $language = $lang  # Normalize to config case
                    $languageFound = $true
                    break  # Exit the foreach loop
                }
            }
        
            if ($languageFound) {
                break  # Exit the while loop - valid language found
            }
            else {
                Write-Host "[ERROR] Unsupported language. Supported languages are: $($config.supportedLanguages -join ', ')." -ForegroundColor Red
            }
        }
        else {
            Write-Host "[ERROR] Language cannot be empty." -ForegroundColor Red
        }
    }

    # Get problem data for metadata
    $problemData = Get-ProblemDataFromCache -problemNumber $problemNumber
    if (-not $problemData) {
        Write-Host "[WARNING] Problem data not found in cache, but continuing with removal..." -ForegroundColor Yellow
    }

    # Find the problem folder
    $problemFolderPath = Find-ProblemFolder -problemNumber $problemNumber -language $language
    if (-not $problemFolderPath) {
        return
    }

    # Confirm removal
    Write-Host "`n[WARNING] You are about to remove the following problem:" -ForegroundColor Yellow
    Write-Host "  Problem Number: $problemNumber" -ForegroundColor White
    Write-Host "  Language: $language" -ForegroundColor White
    Write-Host "  Folder Path: $problemFolderPath" -ForegroundColor White
    if ($problemData) {
        Write-Host "  Problem Title: $($problemData.stat.question__title)" -ForegroundColor White
    }
    
    $confirmation = Read-Host "`nAre you sure you want to remove this problem? (y/N)"
    if ($confirmation -ne 'y' -and $confirmation -ne 'Y') {
        Write-Host "[INFO] Removal cancelled." -ForegroundColor Blue
        return
    }

    # Perform language-specific operations before removing folder
    if ($problemData) {
        Write-Host "[WORKING] Performing language-specific cleanup for $language..." -ForegroundColor Yellow
        switch ($language.ToLower()) {
            'csharp' { CSharpRemovalOperations -problemFolderPath $problemFolderPath -questionTitle $problemData.stat.question__title }
            default  { Write-Host "[INFO] No specific cleanup operations defined for language $language." -ForegroundColor Blue }
        }
    }

    # Remove the problem folder
    $success = Remove-ProblemFolder -folderPath $problemFolderPath
    if ($success) {
        Write-Host "`n[SUCCESS] Problem $problemNumber ($language) has been successfully removed." -ForegroundColor Green
    }
    else {
        Write-Host "`n[ERROR] Failed to remove problem $problemNumber ($language)." -ForegroundColor Red
    }
}

# Invoke the main function
Main
