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

function Convert-PathForRegistry {
    param([string]$path)
    # Convert to forward slashes for cross-platform registry storage
    return $path -replace '\\', '/'
}

function Build-ProblemFolderName {
    param([string]$problemNumber, [string]$titleSlug)

    $paddedId = Get-PaddedProblemId -problemNumber $problemNumber
    return "$paddedId-$titleSlug"
}

function Copy-TemplateFiles {
    param([string]$templatePath, [string]$destinationPath)

    if (-not (Test-Path $templatePath)) {
        Write-Host "[ERROR] Template path $templatePath does not exist." -ForegroundColor Red
        return $false
    }

    try {
        Copy-Item -Path (Join-Path $templatePath "*") -Destination $destinationPath -Recurse
        Write-Host "[SUCCESS] Copied template files to $destinationPath" -ForegroundColor Green
    }
    catch {
        Write-Host "[ERROR] Failed to copy template files: $($_.Exception.Message)" -ForegroundColor Red
    }
}

function PascalCaseConverter {
    param([string]$inputString)

    $words = $inputString -split '[-_ ]'
    $pascalCase = ($words | ForEach-Object { $_.Substring(0, 1).ToUpper() + $_.Substring(1).ToLower() }) -join ''
    return $pascalCase
}

function SnakeCaseConverter {
    param([string]$inputString)

    $words = $inputString -split '[-_ ]'
    $snakeCase = ($words | ForEach-Object { $_.ToLower() }) -join '_'
    return $snakeCase
}

function Update-Template {
    param([string]$destinationPath, [string]$projectName)

    try {
        # Get all files in the destination path recursively
        $files = Get-ChildItem -Path $destinationPath -File -Recurse

        foreach ($file in $files) {
            # Read the file content
            $content = Get-Content -Path $file.FullName -Raw -ErrorAction SilentlyContinue
            
            if ($content -and $content.Contains("Template")) {
                # Replace all occurrences of "Template" with the project name
                $updatedContent = $content -replace "Template", $projectName
                
                # Write the updated content back to the file
                Set-Content -Path $file.FullName -Value $updatedContent -NoNewline
                Write-Host "[SUCCESS] Updated template placeholders in $($file.Name)" -ForegroundColor Green
            }
        }
    }
    catch {
        Write-Host "[ERROR] Failed to update template placeholders: $($_.Exception.Message)" -ForegroundColor Red
    }
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

function Add-ProblemToRegistry {
    param(
        [string]$problemNumber,
        [string]$language,
        [string]$titleSlug,
        [string]$questionTitle,
        [string]$projectName,
        [string]$folderPath
    )

    try {
        Initialize-ProblemRegistry
        $registry = Get-Content $registryFile -Raw | ConvertFrom-Json

        # Convert PSCustomObject to hashtable for dynamic property support
        $registryHash = @{}
        $registry.PSObject.Properties | ForEach-Object {
            $registryHash[$_.Name] = $_.Value
        }

        # Ensure the language array exists
        if (-not $registryHash.$language) {
            $registryHash.$language = @()
        }

        # Create problem entry
        $problemEntry = @{
            problemNumber = $problemNumber
            titleSlug     = $titleSlug
            questionTitle = $questionTitle
            projectName   = $projectName
            folderPath    = $folderPath
            createdDate   = (Get-Date).ToString("yyyy-MM-ddTHH:mm:ssZ")
        }

        # Convert to array if it's not already
        $problemArray = @($registryHash.$language)
        $problemArray += $problemEntry
        $registryHash.$language = $problemArray

        # Convert back to object and save
        $registryHash | ConvertTo-Json -Depth 10 | Set-Content $registryFile
        Write-Host "[SUCCESS] Added problem to registry." -ForegroundColor Green
    }
    catch {
        Write-Host "[ERROR] Failed to add problem to registry: $($_.Exception.Message)" -ForegroundColor Red
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

function CSharpOperations {
    param([string]$destinationPath, [string]$questionTitle)

    $projectName = PascalCaseConverter -input $questionTitle
    $csprojPath = Join-Path $destinationPath "$projectName.csproj"

    # Create a new xUnit project
    Write-Host "[WORKING] Setting up C# project..." -ForegroundColor Yellow
    dotnet new xunit -n $projectName -o $destinationPath -f net9.0 | Out-Null
    Remove-Item -Path (Join-Path $destinationPath "UnitTest1.cs") -ErrorAction SilentlyContinue
    Write-Host "[SUCCESS] Created C# xUnit project $projectName" -ForegroundColor Green

    # Update template placeholders in copied files
    Write-Host "[WORKING] Updating template placeholders..." -ForegroundColor Yellow
    Update-Template -destinationPath $destinationPath -projectName $projectName
    Write-Host "[SUCCESS] Updated template placeholders." -ForegroundColor Green

    # Add the project into the solution
    Write-Host "[WORKING] Adding project to solution..." -ForegroundColor Yellow
    $solutionPath = Join-Path $PSScriptRoot ".." "problems" "csharp" "LeetCode.slnx"
    dotnet sln $solutionPath add $csprojPath | Out-Null
    Write-Host "[SUCCESS] Added project $projectName to solution." -ForegroundColor Green
    Write-Host "[SUCCESS] C# project setup completed." -ForegroundColor Green
}

function COperations {
    param([string]$destinationPath, [string]$questionTitle)

    $projectName = SnakeCaseConverter -input $questionTitle

    # Update template placeholders in copied files
    Write-Host "[WORKING] Updating template placeholders..." -ForegroundColor Yellow
    Update-Template -destinationPath $destinationPath -projectName $projectName
    Write-Host "[SUCCESS] Updated template placeholders." -ForegroundColor Green

    # Run CMake to configure the project
    Write-Host "[WORKING] Configuring C project with CMake..." -ForegroundColor Yellow
    $buildDir = Join-Path $destinationPath "build"
    if (-not (Test-Path $buildDir)) {
        New-Item -ItemType Directory -Path $buildDir | Out-Null
    }

    cmake -S $destinationPath -B $buildDir | Out-Null
    if ($LASTEXITCODE -ne 0) {
        Write-Host "[ERROR] CMake configuration failed." -ForegroundColor Red
        return
    } else {
        Write-Host "[SUCCESS] CMake configuration completed." -ForegroundColor Green
    }
}

#endregion

function Main {
    Write-Host "[WORKING] Creating new problem..." -ForegroundColor Yellow
    Update-ProblemCache
    Write-Host "[SUCCESS] Problem cache is ready." -ForegroundColor Green

    # Prompt user for problem number
    while ($true) {
        $problemNumber = Read-Host "Enter the LeetCode problem number (or 'exit' to quit)"
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


    # Building problem folder name and folder path
    $problemData = Get-ProblemDataFromCache -problemNumber $problemNumber
    if (-not $problemData) {
        return
    }

    # Check if problem already exists in registry
    $existingProblem = Get-ProblemFromRegistry -problemNumber $problemNumber -language $language
    if ($existingProblem) {
        Write-Host "[ERROR] Problem $problemNumber already exists for language $language" -ForegroundColor Red
        Write-Host "[INFO] Existing problem details:" -ForegroundColor Blue
        Write-Host "  Title: $($existingProblem.questionTitle)" -ForegroundColor Gray
        Write-Host "  Folder: $($existingProblem.folderPath)" -ForegroundColor Gray
        Write-Host "  Created: $($existingProblem.createdDate)" -ForegroundColor Gray
        return
    }

    $titleSlug = $problemData.stat.question__title_slug
    $problemFolderName = Build-ProblemFolderName -problemNumber $problemNumber -titleSlug $titleSlug

    $destinationPath = Join-Path $PSScriptRoot ".." $config.problemPath.$language $problemFolderName
    if (Test-Path $destinationPath) {
        Write-Host "[ERROR] Problem folder already exists at $destinationPath" -ForegroundColor Red
        return
    }
    else {
        New-Item -ItemType Directory -Path $destinationPath | Out-Null
        Copy-TemplateFiles -templatePath (Join-Path $PSScriptRoot ".." $config.templatePath.$language) -destinationPath $destinationPath
        Write-Host "[SUCCESS] Created problem at $destinationPath" -ForegroundColor Green
    }

    # Perform language-specific operations
    Write-Host "[WORKING] Performing language-specific operations for $language..." -ForegroundColor Yellow
    switch ($language.ToLower()) {
        'csharp' { CSharpOperations -destinationPath $destinationPath -questionTitle $problemData.stat.question__title }
        'c' { COperations -destinationPath $destinationPath -questionTitle $problemData.stat.question__title }
        default { Write-Host "[ERROR] No operations defined for language $language." -ForegroundColor Red }
    }

    # Add problem to registry
    Write-Host "[WORKING] Adding problem to registry..." -ForegroundColor Yellow
    $projectName = if ($language.ToLower() -eq 'csharp') { 
        PascalCaseConverter -inputString $problemData.stat.question__title 
    }
    elseif ($language.ToLower() -eq 'c') {
        SnakeCaseConverter -inputString $problemData.stat.question__title
    }
    else {
        $problemData.stat.question__title
    }

    Add-ProblemToRegistry -problemNumber $problemNumber -language $language -titleSlug $titleSlug -questionTitle $problemData.stat.question__title -projectName $projectName -folderPath (Convert-PathForRegistry -path $destinationPath)

    Write-Host "`n[SUCCESS] Problem $problemNumber ($($problemData.stat.question__title)) has been successfully created for $language!" -ForegroundColor Green
}

# Invoke the main function
Main