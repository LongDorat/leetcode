# An interactive script to help users setup the environment for solving LeetCode problems in PowerShell.
# It guides the user through creating or removing a problem, and running tests.

#Requires -Version 5.1

# ============================================================================
# GLOBAL VARIABLES
# ============================================================================

$script:NewProblemScript = Join-Path $PSScriptRoot "scripts\NewProblem.ps1"
$script:RunTestScript = Join-Path $PSScriptRoot "scripts\RunTest.ps1"
$script:RemoveProblemScript = Join-Path $PSScriptRoot "scripts\RemoveProblem.ps1"
$script:ListProblemScript = Join-Path $PSScriptRoot "scripts\ListProblems.ps1"

# ============================================================================
# HELPER FUNCTIONS
# ============================================================================

function Show-Banner {
    Write-Host ""
    Write-Host "╔══════════════════════════════════════════════════════════════╗" -ForegroundColor Cyan
    Write-Host "║                                                              ║" -ForegroundColor Cyan
    Write-Host "║           " -NoNewline -ForegroundColor Cyan
    Write-Host "🚀 LeetCode Collection Terminal 🚀" -NoNewline -ForegroundColor Yellow
    Write-Host "                 ║" -ForegroundColor Cyan
    Write-Host "║                                                              ║" -ForegroundColor Cyan
    Write-Host "╚══════════════════════════════════════════════════════════════╝" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "📚 Solve LeetCode problems with style!" -ForegroundColor Green
    Write-Host ""
}

function Show-Menu {
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host "  📋 Main Menu" -ForegroundColor Cyan
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host ""
    
    Write-Host "  [" -NoNewline -ForegroundColor DarkGray
    Write-Host "1" -NoNewline -ForegroundColor Green
    Write-Host "] " -NoNewline -ForegroundColor DarkGray
    Write-Host "✨ Create new problem" -ForegroundColor White
    
    Write-Host "  [" -NoNewline -ForegroundColor DarkGray
    Write-Host "2" -NoNewline -ForegroundColor Yellow
    Write-Host "] " -NoNewline -ForegroundColor DarkGray
    Write-Host "🧪 Run tests" -ForegroundColor White
    
    Write-Host "  [" -NoNewline -ForegroundColor DarkGray
    Write-Host "3" -NoNewline -ForegroundColor Red
    Write-Host "] " -NoNewline -ForegroundColor DarkGray
    Write-Host "🗑️ Remove problem" -ForegroundColor White
    
    Write-Host "  [" -NoNewline -ForegroundColor DarkGray
    Write-Host "4" -NoNewline -ForegroundColor Magenta
    Write-Host "] " -NoNewline -ForegroundColor DarkGray
    Write-Host "📋 List all problems" -ForegroundColor White
    
    Write-Host "  [" -NoNewline -ForegroundColor DarkGray
    Write-Host "0" -NoNewline -ForegroundColor DarkGray
    Write-Host "] " -NoNewline -ForegroundColor DarkGray
    Write-Host "👋 Exit" -ForegroundColor DarkGray
    
    Write-Host ""
    Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
    Write-Host ""
}

function Invoke-MenuChoice {
    param([string]$Choice)
    
    switch ($Choice) {
        "1" {
            Clear-Host
            & $script:NewProblemScript
            return $true
        }
        "2" {
            Clear-Host
            & $script:RunTestScript
            return $true
        }
        "3" {
            Clear-Host
            & $script:RemoveProblemScript
            return $true
        }
        "4" {
            Clear-Host
            & $script:ListProblemScript
            return $true
        }
        "0" {
            Write-Host ""
            Write-Host "👋 " -NoNewline -ForegroundColor Cyan
            Write-Host "Goodbye! Happy coding!" -ForegroundColor White
            Write-Host ""
            return $false
        }
        default {
            Write-Host ""
            Write-Host "❌ Invalid choice: " -NoNewline -ForegroundColor Red
            Write-Host "'$Choice'" -ForegroundColor Yellow
            Write-Host "   Please select a number from the menu (0-4)" -ForegroundColor DarkGray
            Write-Host ""
            Start-Sleep -Seconds 1
            return $true
        }
    }
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

# Main menu loop
while ($true) {
    Clear-Host
    Show-Banner
    Show-Menu
    
    Write-Host "Enter your choice: " -NoNewline -ForegroundColor Cyan
    $userChoice = Read-Host
    
    $continue = Invoke-MenuChoice -Choice $userChoice
    
    if (-not $continue) {
        break
    }
    
    # If we get here and the choice was invalid, redraw the banner
    if ($userChoice -notin @("0", "1", "2", "3", "4")) {
        Clear-Host
        Show-Banner
    }
}