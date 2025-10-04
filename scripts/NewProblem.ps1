# An interactive script to help users create a new LeetCode problem in PowerShell.
# This script fetches problem data from cache and creates a new problem folder from templates.

#Requires -Version 5.1

# ============================================================================
# MODULE IMPORTS
# ============================================================================

Import-Module (Join-Path $PSScriptRoot "module" "LanguageOperations.psm1") -Force

# ============================================================================
# GLOBAL VARIABLES
# ============================================================================

$script:ConfigPath = Join-Path $PSScriptRoot .. config config.json
$script:FetchDataScriptPath = Join-Path $PSScriptRoot "FetchDataFromLeetCode.ps1"
$script:CachePath = Join-Path $PSScriptRoot .. cache problems.json
$script:ProblemsConfigPath = Join-Path $PSScriptRoot .. config problems.json
$script:MainMenuScriptPath = Join-Path $PSScriptRoot .. "LeetCode.ps1"

$script:config = $null
$script:cache = $null
$script:problemsConfig = $null

# ============================================================================
# HELPER FUNCTIONS
# ============================================================================

function Show-Banner {
    Write-Host ""
    Write-Host "╔══════════════════════════════════════════════════════════════╗" -ForegroundColor Cyan
    Write-Host "║                                                              ║" -ForegroundColor Cyan
    Write-Host "║              " -NoNewline -ForegroundColor Cyan
    Write-Host "✨ Create New Problem ✨" -NoNewline -ForegroundColor Yellow
    Write-Host "                        ║" -ForegroundColor Cyan
    Write-Host "║                                                              ║" -ForegroundColor Cyan
    Write-Host "╚══════════════════════════════════════════════════════════════╝" -ForegroundColor Cyan
    Write-Host ""
}

function Initialize-Configuration {
    <#
    .SYNOPSIS
    Loads configuration files and validates they exist.
    #>
    [CmdletBinding()]
    param()
    
    Write-Host "⚙️  Loading configuration..." -ForegroundColor Cyan
    
    # Load config
    if (-not (Test-Path $script:ConfigPath)) {
        Write-Host "❌ Configuration file not found at:" -ForegroundColor Red
        Write-Host "   $script:ConfigPath" -ForegroundColor DarkGray
        return $false
    }
    $script:config = Get-Content $script:ConfigPath | ConvertFrom-Json
    
    # Load cache
    if (-not (Test-Path $script:CachePath)) {
        Write-Host "❌ Cache file not found. Please run the data fetcher first." -ForegroundColor Red
        return $false
    }
    $script:cache = Get-Content $script:CachePath | ConvertFrom-Json
    
    # Load or create problems config
    if (Test-Path $script:ProblemsConfigPath) {
        $script:problemsConfig = Get-Content $script:ProblemsConfigPath | ConvertFrom-Json
    } else {
        $script:problemsConfig = @()
    }
    
    Write-Host "✅ Configuration loaded successfully!" -ForegroundColor Green
    Write-Host ""
    return $true
}

function Get-UserInput {
    <#
    .SYNOPSIS
    Prompts the user for input with formatted text and example.
    #>
    [CmdletBinding()]
    param(
        [string]$Prompt, 
        [string]$Example, 
        [string]$Icon = "📝"
    )
    
    Write-Host "$Icon " -NoNewline -ForegroundColor Yellow
    Write-Host "$Prompt " -NoNewline -ForegroundColor Cyan
    Write-Host "($Example)" -NoNewline -ForegroundColor DarkGray
    Write-Host ": " -NoNewline -ForegroundColor White
    return Read-Host
}

function Test-ProblemNumber {
    <#
    .SYNOPSIS
    Validates if a problem number is valid and exists in the cache.
    #>
    [CmdletBinding()]
    param([string]$ProblemNumber)
    
    # Check if it's a valid number
    if (-not ($ProblemNumber -match '^\d+$')) {
        Write-Host "❌ Problem number must be a positive integer." -ForegroundColor Red
        return $false
    }
    
    # Check for leading zeros
    if ($ProblemNumber -match '^0\d+') {
        Write-Host "❌ Problem number should not have leading zeros (use 1 instead of 001)." -ForegroundColor Red
        return $false
    }
    
    # Check if problem exists in cache
    $problemNum = [int]$ProblemNumber
    $problem = $script:cache.stat_status_pairs | Where-Object { $_.stat.frontend_question_id -eq $problemNum }
    
    if (-not $problem) {
        Write-Host "❌ Problem #$ProblemNumber not found in LeetCode database." -ForegroundColor Red
        Write-Host "   Try updating the cache or verify the problem number." -ForegroundColor DarkGray
        return $false
    }
    
    return $true
}

function Test-Language {
    <#
    .SYNOPSIS
    Validates if a programming language is supported.
    #>
    [CmdletBinding()]
    param([string]$Language)
    
    if (-not ($script:config.supportedLanguages -contains $Language)) {
        Write-Host "❌ Unsupported programming language: " -NoNewline -ForegroundColor Red
        Write-Host "'$Language'" -ForegroundColor Yellow
        Write-Host ""
        Write-Host "   Supported languages:" -ForegroundColor DarkGray
        foreach ($lang in $script:config.supportedLanguages) {
            Write-Host "   • " -NoNewline -ForegroundColor DarkGray
            Write-Host "$lang" -ForegroundColor Green
        }
        return $false
    }
    
    return $true
}

function New-ProblemDirectory {
    <#
    .SYNOPSIS
    Creates a new problem directory from template.
    
    .DESCRIPTION
    Creates a new directory for a LeetCode problem, copying template files
    and setting up the problem structure.
    #>
    [CmdletBinding()]
    param(
        [int]$ProblemNumber,
        [string]$Language,
        [string]$TemplateDirectory,
        [string]$ProblemDirectory
    )
    
    # Find problem in cache
    $problem = $script:cache.stat_status_pairs | Where-Object { $_.stat.frontend_question_id -eq $ProblemNumber }
    
    if (-not $problem) {
        Write-Host "❌ Problem #$ProblemNumber not found in cache." -ForegroundColor Red
        return $null
    }
    
    # Create problem directory name
    $paddedNumber = $ProblemNumber.ToString().PadLeft(4, '0')
    $titleSlug = $problem.stat.question__title_slug
    $newProblemDirectory = Join-Path $ProblemDirectory "$paddedNumber-$titleSlug"
    
    # Check if already exists
    if (Test-Path $newProblemDirectory) {
        Write-Host "❌ Problem already exists:" -ForegroundColor Red
        Write-Host "   $newProblemDirectory" -ForegroundColor DarkGray
        Write-Host ""
        Write-Host "   Use option 3 to remove it first if you want to recreate it." -ForegroundColor Yellow
        return $null
    }
    
    # Show progress
    Write-Host ""
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host "  📦 Creating Problem Structure" -ForegroundColor Cyan
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host ""
    
    Write-Host "  Problem: " -NoNewline -ForegroundColor DarkGray
    Write-Host "#$ProblemNumber - $titleSlug" -ForegroundColor White
    Write-Host "  Language: " -NoNewline -ForegroundColor DarkGray
    Write-Host "$Language" -ForegroundColor Green
    Write-Host "  Difficulty: " -NoNewline -ForegroundColor DarkGray
    
    $difficulty = $problem.difficulty.level
    $diffColor = switch ($difficulty) {
        1 { "Green" }
        2 { "Yellow" }
        3 { "Red" }
        default { "White" }
    }
    $diffText = switch ($difficulty) {
        1 { "Easy" }
        2 { "Medium" }
        3 { "Hard" }
        default { "Unknown" }
    }
    Write-Host "$diffText" -ForegroundColor $diffColor
    Write-Host ""
    
    try {
        # Create directory
        Write-Host "  [1/3] Creating directory..." -ForegroundColor Cyan
        New-Item -ItemType Directory -Path $newProblemDirectory -Force | Out-Null
        Start-Sleep -Milliseconds 200
        Write-Host "        ✅ Directory created" -ForegroundColor Green
        
        # Copy template files
        Write-Host "  [2/3] Copying template files..." -ForegroundColor Cyan
        Copy-Item -Path (Join-Path $TemplateDirectory "*") -Destination $newProblemDirectory -Recurse -Force
        Start-Sleep -Milliseconds 200
        Write-Host "        ✅ Template copied" -ForegroundColor Green
        
        # Finalize
        Write-Host "  [3/3] Finalizing..." -ForegroundColor Cyan
        Start-Sleep -Milliseconds 200
        Write-Host "        ✅ Problem ready!" -ForegroundColor Green
        
        Write-Host ""
        Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
        Write-Host ""
        Write-Host "🎉 Success! Problem created at:" -ForegroundColor Green
        Write-Host "   $newProblemDirectory" -ForegroundColor White
        Write-Host ""
        
        return $newProblemDirectory
    }
    catch {
        Write-Host ""
        Write-Host "❌ Failed to create problem directory" -ForegroundColor Red
        Write-Host "   Error: $($_.Exception.Message)" -ForegroundColor DarkGray
        return $null
    }
}

function Add-ProblemToConfig {
    <#
    .SYNOPSIS
    Adds a new problem entry to the problems configuration file.
    #>
    [CmdletBinding()]
    param(
        [int]$ProblemNumber,
        [string]$Language,
        [string]$ProblemDirectory
    )
    
    if (-not $ProblemDirectory) {
        return
    }
    
    $newEntry = @{
        question_id = $ProblemNumber
        language = $Language
        date = (Get-Date).ToString("yyyy-MM-dd HH:mm:ss")
        path = $ProblemDirectory
    }
    
    $problemsList = [System.Collections.ArrayList]@()
    if ($script:problemsConfig) {
        $problemsList.AddRange($script:problemsConfig)
    }
    $problemsList.Add($newEntry) | Out-Null
    
    # Save to file
    $problemsList | ConvertTo-Json -Depth 10 | Set-Content $script:ProblemsConfigPath -Encoding UTF8
    
    Write-Host "💾 Problem tracked in configuration" -ForegroundColor Cyan
}

function Show-ReturnPrompt {
    <#
    .SYNOPSIS
    Displays a prompt to return to the main menu.
    #>
    [CmdletBinding()]
    param()
    
    Write-Host ""
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host ""
    Write-Host "Press any key to return to main menu..." -ForegroundColor DarkGray
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}

# ============================================================================
# MAIN EXECUTION
# ============================================================================

# Setup console
$Host.UI.RawUI.BackgroundColor = "Black"
$Host.UI.RawUI.ForegroundColor = "White"
Clear-Host

# Run data fetcher
& $script:FetchDataScriptPath

# Show banner
Show-Banner

Write-Host "📚 Create a new LeetCode problem with ease!" -ForegroundColor Green
Write-Host ""

# Initialize configuration
if (-not (Initialize-Configuration)) {
    Write-Host ""
    Write-Host "Failed to initialize. Please check your setup." -ForegroundColor Red
    Show-ReturnPrompt
    exit 1
}

# Get user input with validation loop
$problemNumber = $null
$language = $null

Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
Write-Host "  � Problem Information" -ForegroundColor Cyan
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
Write-Host ""

# Get problem number
while ($true) {
    $userInput = Get-UserInput -Prompt "Problem Number" -Example "1, 23, 456" -Icon "🔢"
    
    if ([string]::IsNullOrWhiteSpace($userInput)) {
        Write-Host "⚠️  Problem number cannot be empty" -ForegroundColor Yellow
        Write-Host ""
        continue
    }
    
    if (Test-ProblemNumber -ProblemNumber $userInput) {
        $problemNumber = [int]$userInput
        Write-Host "✅ Valid problem number" -ForegroundColor Green
        Write-Host ""
        break
    }
    Write-Host ""
}

# Get language
while ($true) {
    $userInput = Get-UserInput -Prompt "Programming Language" -Example "csharp, python, java" -Icon "💻"
    
    if ([string]::IsNullOrWhiteSpace($userInput)) {
        Write-Host "⚠️  Language cannot be empty" -ForegroundColor Yellow
        Write-Host ""
        continue
    }
    
    if (Test-Language -Language $userInput.ToLower()) {
        $language = $userInput.ToLower()
        Write-Host "✅ Valid language" -ForegroundColor Green
        break
    }
    Write-Host ""
}

# Create the problem
$templateDirectory = Join-Path $PSScriptRoot .. "$($script:config.templatePath.$language)"
$problemDirectory = Join-Path $PSScriptRoot .. "$($script:config.problemPath.$language)"

$createdProblemDirectory = New-ProblemDirectory -ProblemNumber $problemNumber -Language $language -TemplateDirectory $templateDirectory -ProblemDirectory $problemDirectory

# Add to config
Add-ProblemToConfig -ProblemNumber $problemNumber -Language $language -ProblemDirectory $createdProblemDirectory

# Update problem template
if ($createdProblemDirectory) {
    $problemDetails = $script:cache.stat_status_pairs | Where-Object { $_.stat.frontend_question_id -eq $problemNumber } | Select-Object -First 1
    Update-ProblemTemplate -ProblemDirectory $createdProblemDirectory -Language $language -ProblemDetails $problemDetails.stat
}

# Return to menu
Show-ReturnPrompt