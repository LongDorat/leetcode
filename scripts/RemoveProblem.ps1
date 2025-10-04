# An interactive script to help users remove a LeetCode problem in PowerShell.
# This script removes a problem directory and updates the problems.json configuration.

#Requires -Version 5.1
# ============================================================================
# MODULE IMPORTS
# ============================================================================

Import-Module (Join-Path $PSScriptRoot "module" "languages" "CSharp.psm1") -Force

# ============================================================================
# GLOBAL VARIABLES
# ============================================================================

$script:ConfigFilePath = Join-Path $PSScriptRoot .. config config.json
$script:ProblemsFilePath = Join-Path $PSScriptRoot .. config problems.json
$script:CacheFilePath = Join-Path $PSScriptRoot .. cache problems.json
$script:MainMenuScript = Join-Path $PSScriptRoot .. "LeetCode.ps1"

$script:config = $null
$script:problemsConfig = $null
$script:cache = $null

# ============================================================================
# HELPER FUNCTIONS
# ============================================================================

function Show-Banner {
    Write-Host ""
    Write-Host "╔══════════════════════════════════════════════════════════════╗" -ForegroundColor Cyan
    Write-Host "║                                                              ║" -ForegroundColor Cyan
    Write-Host "║              " -NoNewline -ForegroundColor Cyan
    Write-Host "🗑️  Remove Problem 🗑️" -NoNewline -ForegroundColor Red
    Write-Host "                           ║" -ForegroundColor Cyan
    Write-Host "║                                                              ║" -ForegroundColor Cyan
    Write-Host "╚══════════════════════════════════════════════════════════════╝" -ForegroundColor Cyan
    Write-Host ""
}

function Initialize-Configuration {
    Write-Host "⚙️  Loading configuration..." -ForegroundColor Cyan
    
    # Load config
    if (-not (Test-Path $script:ConfigFilePath)) {
        Write-Host "❌ Configuration file not found at:" -ForegroundColor Red
        Write-Host "   $script:ConfigFilePath" -ForegroundColor DarkGray
        return $false
    }
    $script:config = Get-Content $script:ConfigFilePath | ConvertFrom-Json
    
    # Load problems config
    if (-not (Test-Path $script:ProblemsFilePath)) {
        Write-Host "⚠️  No problems found. Nothing to remove!" -ForegroundColor Yellow
        return $false
    }
    
    $content = Get-Content $script:ProblemsFilePath -Raw
    if ([string]::IsNullOrWhiteSpace($content)) {
        Write-Host "⚠️  No problems found. Nothing to remove!" -ForegroundColor Yellow
        return $false
    }
    
    $script:problemsConfig = Get-Content $script:ProblemsFilePath | ConvertFrom-Json
    
    # Load cache for problem details
    if (Test-Path $script:CacheFilePath) {
        $script:cache = Get-Content $script:CacheFilePath | ConvertFrom-Json
    }
    
    Write-Host "✅ Configuration loaded successfully!" -ForegroundColor Green
    Write-Host ""
    return $true
}

function Get-UserInput {
    param([string]$Prompt, [string]$Example, [string]$Icon = "📝")
    
    Write-Host "$Icon " -NoNewline -ForegroundColor Yellow
    Write-Host "$Prompt " -NoNewline -ForegroundColor Cyan
    Write-Host "($Example)" -NoNewline -ForegroundColor DarkGray
    Write-Host ": " -NoNewline -ForegroundColor White
    return Read-Host
}

function Get-ProblemDetails {
    param([int]$QuestionId)
    
    if ($script:cache) {
        $problem = $script:cache.stat_status_pairs | Where-Object { $_.stat.frontend_question_id -eq $QuestionId }
        if ($problem) {
            return @{
                Title = $problem.stat.question__title
                TitleSlug = $problem.stat.question__title_slug
                Difficulty = switch ($problem.difficulty.level) {
                    1 { "Easy" }
                    2 { "Medium" }
                    3 { "Hard" }
                    default { "Unknown" }
                }
                DifficultyLevel = $problem.difficulty.level
            }
        }
    }
    
    return @{
        Title = "Unknown"
        TitleSlug = "unknown"
        Difficulty = "Unknown"
        DifficultyLevel = 0
    }
}

function Show-AvailableProblems {
    if ($script:problemsConfig.Count -eq 0) {
        return
    }
    
    Write-Host "📋 Available Problems:" -ForegroundColor Cyan
    Write-Host ""
    
    # Group by language
    $groupedByLanguage = $script:problemsConfig | Group-Object -Property language
    
    foreach ($langGroup in $groupedByLanguage) {
        $language = $langGroup.Name
        $problems = $langGroup.Group
        
        Write-Host "  💻 " -NoNewline -ForegroundColor Cyan
        Write-Host "$($language.ToUpper())" -ForegroundColor Yellow
        
        # Sort by question_id
        $sortedProblems = $problems | Sort-Object -Property question_id
        
        foreach ($problem in $sortedProblems) {
            $details = Get-ProblemDetails -QuestionId $problem.question_id
            
            # Problem number
            Write-Host "     #" -NoNewline -ForegroundColor DarkGray
            Write-Host "$($problem.question_id.ToString().PadRight(5))" -NoNewline -ForegroundColor White
            
            # Difficulty
            $diffColor = switch ($details.DifficultyLevel) {
                1 { "Green" }
                2 { "Yellow" }
                3 { "Red" }
                default { "White" }
            }
            Write-Host "[" -NoNewline -ForegroundColor DarkGray
            Write-Host "$($details.Difficulty.PadRight(6))" -NoNewline -ForegroundColor $diffColor
            Write-Host "] " -NoNewline -ForegroundColor DarkGray
            
            # Title
            Write-Host "$($details.Title)" -ForegroundColor Cyan
        }
        
        Write-Host ""
    }
    
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host ""
}

function Test-ProblemExists {
    param([string]$ProblemNumber, [string]$Language)
    
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
    
    # Check if problem exists in configuration with specified language
    $problemNum = [int]$ProblemNumber
    $problem = $script:problemsConfig | Where-Object { 
        $_.question_id -eq $problemNum -and $_.language -eq $Language 
    }
    
    if (-not $problem) {
        Write-Host "❌ Problem #$ProblemNumber in language '$Language' not found in your collection." -ForegroundColor Red
        Write-Host "   Use option 4 to see all available problems." -ForegroundColor DarkGray
        return $false
    }
    
    return $true
}

function Test-Language {
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

function Get-ConfirmationPrompt {
    param([string]$Message)
    
    Write-Host "$Message " -NoNewline -ForegroundColor Yellow
    Write-Host "[" -NoNewline -ForegroundColor DarkGray
    Write-Host "y" -NoNewline -ForegroundColor Green
    Write-Host "/" -NoNewline -ForegroundColor DarkGray
    Write-Host "N" -NoNewline -ForegroundColor Red
    Write-Host "]: " -NoNewline -ForegroundColor DarkGray
    
    $response = Read-Host
    return $response -eq "y" -or $response -eq "Y" -or $response -eq "yes" -or $response -eq "Yes"
}

function Remove-ProblemFromDisk {
    param([int]$ProblemNumber, [string]$Language)
    
    # Find the problem with specific language
    $problem = $script:problemsConfig | Where-Object { 
        $_.question_id -eq $ProblemNumber -and $_.language -eq $Language 
    }
    
    if (-not $problem) {
        return $false
    }
    
    $details = Get-ProblemDetails -QuestionId $ProblemNumber
    
    # Show what will be removed
    Write-Host ""
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host "  🗑️  Removing Problem" -ForegroundColor Red
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host ""
    
    Write-Host "  Problem: " -NoNewline -ForegroundColor DarkGray
    Write-Host "#$ProblemNumber - $($details.Title)" -ForegroundColor White
    Write-Host "  Language: " -NoNewline -ForegroundColor DarkGray
    Write-Host "$($problem.language)" -ForegroundColor Green
    Write-Host "  Path: " -NoNewline -ForegroundColor DarkGray
    Write-Host "$($problem.path)" -ForegroundColor Yellow
    Write-Host ""
    
    # Confirm deletion
    if (-not (Get-ConfirmationPrompt -Message "⚠️  Are you sure you want to delete this problem?")) {
        Write-Host ""
        Write-Host "❌ Removal cancelled." -ForegroundColor Yellow
        return $false
    }

    # If C#, remove from solution
    if ($language -eq "csharp") {
        $titleWithoutSpaces = $details.title -replace '\s+', ''
        Remove-CSharpProjectFromSolution -ProblemPath $problem.path -TitleWithoutSpaces $titleWithoutSpaces
    }
    
    Write-Host ""
    Write-Host "  [1/2] Removing directory..." -ForegroundColor Cyan
    
    try {
        # Remove directory if it exists
        if (Test-Path $problem.path) {
            Remove-Item -Path $problem.path -Recurse -Force
            Start-Sleep -Milliseconds 200
            Write-Host "        ✅ Directory removed" -ForegroundColor Green
        } else {
            Write-Host "        ⚠️  Directory not found (skipping)" -ForegroundColor Yellow
        }
        
        Write-Host "  [2/2] Updating configuration..." -ForegroundColor Cyan
        
        # Remove from configuration (remove only the specific problem with this language)
        $updatedProblems = $script:problemsConfig | Where-Object { 
            -not ($_.question_id -eq $ProblemNumber -and $_.language -eq $Language)
        }
        
        if ($updatedProblems.Count -eq 0) {
            # If no problems left, save empty array
            "[]" | Set-Content $script:ProblemsFilePath -Encoding UTF8
        } else {
            $updatedProblems | ConvertTo-Json -Depth 10 | Set-Content $script:ProblemsFilePath -Encoding UTF8
        }
        
        Start-Sleep -Milliseconds 200
        Write-Host "        ✅ Configuration updated" -ForegroundColor Green
        
        Write-Host ""
        Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
        Write-Host ""
        Write-Host "🎉 Problem successfully removed!" -ForegroundColor Green
        Write-Host ""
        
        return $true
    }
    catch {
        Write-Host ""
        Write-Host "❌ Failed to remove problem" -ForegroundColor Red
        Write-Host "   Error: $($_.Exception.Message)" -ForegroundColor DarkGray
        Write-Host ""
        return $false
    }
}

function Show-ReturnPrompt {
    Write-Host ""
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
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

# Show banner
Show-Banner

Write-Host "🗑️  Remove a LeetCode problem from your collection." -ForegroundColor Red
Write-Host ""

# Initialize configuration
if (-not (Initialize-Configuration)) {
    Write-Host ""
    Write-Host "No problems to remove." -ForegroundColor Yellow
    Show-ReturnPrompt
    exit 0
}

# Show available problems
Show-AvailableProblems

# Get user input with validation loop
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
Write-Host "  🔍 Problem Selection" -ForegroundColor Cyan
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
Write-Host ""

$problemNumber = $null
$language = $null

# Get problem number
while ($true) {
    $userInput = Get-UserInput -Prompt "Problem Number to Remove" -Example "1, 23, 456" -Icon "🔢"

    if ([string]::IsNullOrWhiteSpace($userInput)) {
        Write-Host "⚠️  Problem number cannot be empty" -ForegroundColor Yellow
        Write-Host ""
        continue
    }

    if ($userInput -match '^\d+$' -and -not ($userInput -match '^0\d+')) {
        $problemNumber = [int]$userInput
        Write-Host "✅ Valid problem number" -ForegroundColor Green
        Write-Host ""
        break
    }
    
    Write-Host "❌ Invalid problem number format" -ForegroundColor Red
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
    
    if (Test-Language -Language $userInput) {
        $language = $userInput.ToLower()
        
        # Now check if the specific problem + language combination exists
        if (Test-ProblemExists -ProblemNumber $problemNumber -Language $language) {
            Write-Host "✅ Problem found" -ForegroundColor Green
            break
        }
    }
    Write-Host ""
}

# Remove the problem
Remove-ProblemFromDisk -ProblemNumber $problemNumber -Language $language

# Return to menu
Show-ReturnPrompt