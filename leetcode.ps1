# An interactive script to help users setup the environment for solving LeetCode problems in PowerShell.
# It guides the user through creating or removing a problem, and running tests.

$NewProblemScript = Join-Path -Path $PSScriptRoot -ChildPath "scripts\new-problems.ps1"
$RunTestScript = Join-Path -Path $PSScriptRoot -ChildPath "scripts\run-test.ps1"
$RemoveProblemScript = Join-Path -Path $PSScriptRoot -ChildPath "scripts\remove-problem.ps1"
$ListProblemScript = Join-Path -Path $PSScriptRoot -ChildPath "scripts\list-problem.ps1"

# Set console colors and clear screen
$Host.UI.RawUI.BackgroundColor = "Black"
$Host.UI.RawUI.ForegroundColor = "White"
Clear-Host

# Banner with colors
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

# Menu with colors and emojis
Write-Host "Please choose an option:" -ForegroundColor White
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
Write-Host "Enter your choice: " -NoNewline -ForegroundColor Cyan
$UserChoice = Read-Host

switch ($UserChoice){
    "1" { 
        Write-Host ""
        & $NewProblemScript
    }
    "2" { 
        Write-Host ""
        & $RunTestScript
    }
    "3" { 
        Write-Host ""
        & $RemoveProblemScript
    }
    "4" { 
        Write-Host ""
        & $ListProblemScript
    }
    "0" { 
        Write-Host "`n👋 Goodbye! Happy coding!" -ForegroundColor Cyan
        exit 
    }
    default { 
        Write-Host "`n❌ Invalid choice. Please select a number from the menu." -ForegroundColor Red
        Start-Sleep -Seconds 2
        & "$PSScriptRoot\leetcode.ps1"
    }
}