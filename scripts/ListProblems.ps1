# An interactive script to list all created LeetCode problems in PowerShell.
# This script displays problems from the problems.json configuration file.

#Requires -Version 5.1

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
    Write-Host "📋 List All Problems 📋" -NoNewline -ForegroundColor Yellow
    Write-Host "                         ║" -ForegroundColor Cyan
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
        Write-Host "⚠️  No problems found. Create a problem first!" -ForegroundColor Yellow
        return $false
    }
    
    $content = Get-Content $script:ProblemsFilePath -Raw
    if ([string]::IsNullOrWhiteSpace($content)) {
        Write-Host "⚠️  No problems found. Create a problem first!" -ForegroundColor Yellow
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

function Show-ProblemsTable {
    if ($script:problemsConfig.Count -eq 0) {
        Write-Host "📭 No problems found in the collection." -ForegroundColor Yellow
        Write-Host ""
        return
    }
    
    Write-Host "📊 Total Problems: " -NoNewline -ForegroundColor Cyan
    Write-Host "$($script:problemsConfig.Count)" -ForegroundColor White
    Write-Host ""
    
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host ""
    
    # Group by language
    $groupedByLanguage = $script:problemsConfig | Group-Object -Property language
    
    foreach ($langGroup in $groupedByLanguage) {
        $language = $langGroup.Name
        $problems = $langGroup.Group
        
        Write-Host "  💻 " -NoNewline -ForegroundColor Cyan
        Write-Host "$($language.ToUpper())" -NoNewline -ForegroundColor Yellow
        Write-Host " ($($problems.Count) problem(s))" -ForegroundColor DarkGray
        Write-Host ""
        
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
            
            # Date and path
            Write-Host "           Created: " -NoNewline -ForegroundColor DarkGray
            Write-Host "$($problem.date)" -NoNewline -ForegroundColor White
            
            Write-Host ""
        }
        
        Write-Host ""
    }
    
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
}

function Show-Statistics {
    Write-Host ""
    Write-Host "📈 Statistics" -ForegroundColor Cyan
    Write-Host ""
    
    # Count by difficulty
    $easyCount = 0
    $mediumCount = 0
    $hardCount = 0
    
    $uniqueProblems = $script:problemsConfig | Select-Object -Property question_id -Unique

    foreach ($problem in $uniqueProblems) {
        $details = Get-ProblemDetails -QuestionId $problem.question_id
        switch ($details.DifficultyLevel) {
            1 { $easyCount++ }
            2 { $mediumCount++ }
            3 { $hardCount++ }
        }
    }
    
    Write-Host "  Easy:   " -NoNewline -ForegroundColor DarkGray
    Write-Host "$easyCount" -ForegroundColor Green
    
    Write-Host "  Medium: " -NoNewline -ForegroundColor DarkGray
    Write-Host "$mediumCount" -ForegroundColor Yellow
    
    Write-Host "  Hard:   " -NoNewline -ForegroundColor DarkGray
    Write-Host "$hardCount" -ForegroundColor Red
    
    Write-Host ""
    
    # Count by language
    $langCounts = $script:problemsConfig | Group-Object -Property language
    Write-Host "  Languages:" -ForegroundColor DarkGray
    foreach ($langGroup in $langCounts) {
        Write-Host "    • " -NoNewline -ForegroundColor DarkGray
        Write-Host "$($langGroup.Name): " -NoNewline -ForegroundColor Cyan
        Write-Host "$($langGroup.Count)" -ForegroundColor White
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

Write-Host "📚 View all your created LeetCode problems!" -ForegroundColor Green
Write-Host ""

# Initialize configuration
if (-not (Initialize-Configuration)) {
    Write-Host ""
    Write-Host "No problems to display." -ForegroundColor Yellow
    Show-ReturnPrompt
    exit 0
}

# Display problems
Show-ProblemsTable

# Show statistics
if ($script:problemsConfig.Count -gt 0) {
    Show-Statistics
}

# Return to menu
Show-ReturnPrompt