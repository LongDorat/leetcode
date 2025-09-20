# Global Variables
$configPath = Join-Path $PSScriptRoot ".." "config" "config.json"
$config = Get-Content $configPath -Raw | ConvertFrom-Json
$API_URL = "https://leetcode.com/api/problems/all/"
$cacheFile = Join-Path $PSScriptRoot ".." "cache" "problems.json"
$registryFile = Join-Path $PSScriptRoot ".." "config" "problems.json"

#region Helper Functions

function Get-PaddedProblemId {
    param([string]$problemNumber)
    
    $paddingLength = $config.problemIdPadding ?? 4  # Default to 4 digits
    return $problemNumber.PadLeft($paddingLength, '0')
}

function Resolve-PathFromRegistry {
    param([string]$registryPath)
    # Convert forward slashes to platform-specific separators
    return $registryPath -replace '/', [System.IO.Path]::DirectorySeparatorChar
}

function Build-ProblemFolderName {
    param([string]$problemNumber, [string]$titleSlug)

    $paddedId = Get-PaddedProblemId -problemNumber $problemNumber
    return "$paddedId-$titleSlug"
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

#region Registry Management Functions

function Initialize-ProblemRegistry {
    if (-not (Test-Path $registryFile)) {
        Write-Host "[INFO] Creating problem registry file..." -ForegroundColor Blue
        $initialRegistry = @{}
        foreach ($lang in $config.supportedLanguages) {
            $initialRegistry[$lang] = @()
        }
        $initialRegistry | ConvertTo-Json -Depth 10 | Set-Content $registryFile
    }
}

function Get-ProblemFromRegistry {
    param(
        [string]$problemNumber,
        [string]$language
    )

    try {
        if (-not (Test-Path $registryFile)) {
            return $null
        }

        $registry = Get-Content $registryFile -Raw | ConvertFrom-Json
        
        if ($registry.$language) {
            foreach ($problem in $registry.$language) {
                if ($problem.problemNumber -eq $problemNumber) {
                    return $problem
                }
            }
        }
        
        return $null
    }
    catch {
        Write-Host "[ERROR] Failed to read from registry: $($_.Exception.Message)" -ForegroundColor Red
        return $null
    }
}

function Remove-ProblemFromRegistry {
    param(
        [string]$problemNumber,
        [string]$language
    )

    try {
        Initialize-ProblemRegistry
        $registry = Get-Content $registryFile -Raw | ConvertFrom-Json

        if ($registry.$language) {
            $updatedProblems = @()
            foreach ($problem in $registry.$language) {
                if ($problem.problemNumber -ne $problemNumber) {
                    $updatedProblems += $problem
                }
            }
            $registry.$language = $updatedProblems

            # Save back to file
            $registry | ConvertTo-Json -Depth 10 | Set-Content $registryFile
            Write-Host "[SUCCESS] Removed problem from registry." -ForegroundColor Green
            return $true
        }
        
        return $false
    }
    catch {
        Write-Host "[ERROR] Failed to remove problem from registry: $($_.Exception.Message)" -ForegroundColor Red
        return $false
    }
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
    $solutionPath = Join-Path $PSScriptRoot ".." "problems" "csharp" "LeetCode.slnx"
    
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
    Write-Host "[SUCCESS] Problem cache is ready." -ForegroundColor Green

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

    # Get problem from registry
    Write-Host "[WORKING] Looking up problem in registry..." -ForegroundColor Yellow
    $registryProblem = Get-ProblemFromRegistry -problemNumber $problemNumber -language $language
    
    if (-not $registryProblem) {
        Write-Host "[ERROR] Problem number $problemNumber not found in registry for language $language." -ForegroundColor Red
        Write-Host "[INFO] This problem may not have been created using the new-problem script." -ForegroundColor Blue
        return
    }

    $problemFolderPath = Resolve-PathFromRegistry -registryPath $registryProblem.folderPath
    
    # Verify the folder still exists
    if (-not (Test-Path $problemFolderPath)) {
        Write-Host "[WARNING] Problem folder $problemFolderPath no longer exists on disk." -ForegroundColor Yellow
        Write-Host "[INFO] Removing from registry anyway..." -ForegroundColor Blue
    }

    # Get problem data for metadata (fallback to registry data if cache fails)
    $problemData = Get-ProblemDataFromCache -problemNumber $problemNumber
    $questionTitle = if ($problemData) { $problemData.stat.question__title } else { $registryProblem.questionTitle }

    # Confirm removal
    Write-Host "`n[WARNING] You are about to remove the following problem:" -ForegroundColor Yellow
    Write-Host "  Problem Number: $problemNumber" -ForegroundColor White
    Write-Host "  Language: $language" -ForegroundColor White
    Write-Host "  Folder Path: $problemFolderPath" -ForegroundColor White
    Write-Host "  Problem Title: $($registryProblem.questionTitle)" -ForegroundColor White
    Write-Host "  Project Name: $($registryProblem.projectName)" -ForegroundColor White
    Write-Host "  Created Date: $($registryProblem.createdDate)" -ForegroundColor White
    
    $confirmation = Read-Host "`nAre you sure you want to remove this problem? (y/N)"
    if ($confirmation -ne 'y' -and $confirmation -ne 'Y') {
        Write-Host "[INFO] Removal cancelled." -ForegroundColor Blue
        return
    }

    # Perform language-specific operations before removing folder
    Write-Host "[WORKING] Performing language-specific cleanup for $language..." -ForegroundColor Yellow
    switch ($language.ToLower()) {
        'csharp' { CSharpRemovalOperations -problemFolderPath $problemFolderPath -questionTitle $questionTitle }
        default  { Write-Host "[INFO] No specific cleanup operations defined for language $language." -ForegroundColor Blue }
    }

    # Remove the problem folder (only if it exists)
    $folderRemovalSuccess = $true
    if (Test-Path $problemFolderPath) {
        $folderRemovalSuccess = Remove-ProblemFolder -folderPath $problemFolderPath
    }
    
    # Remove from registry
    Write-Host "[WORKING] Removing problem from registry..." -ForegroundColor Yellow
    $registryRemovalSuccess = Remove-ProblemFromRegistry -problemNumber $problemNumber -language $language
    
    # Final status
    if ($folderRemovalSuccess -and $registryRemovalSuccess) {
        Write-Host "`n[SUCCESS] Problem $problemNumber ($language) has been successfully removed." -ForegroundColor Green
    }
    else {
        Write-Host "`n[WARNING] Problem removal completed with some issues:" -ForegroundColor Yellow
        if (-not $folderRemovalSuccess) {
            Write-Host "  - Failed to remove problem folder" -ForegroundColor Red
        }
        if (-not $registryRemovalSuccess) {
            Write-Host "  - Failed to remove from registry" -ForegroundColor Red
        }
    }
}

# Invoke the main function
Main
