# An interactive script to help users create a new LeetCode problem in PowerShell.

# Environment variables
$ConfigFilePath = Join-Path $PSScriptRoot .. config config.json
$FetchDataScript = Join-Path -Path $PSScriptRoot "FetchDataFromLeetCode.ps1"
$CacheFilePath = Join-Path $PSScriptRoot .. cache problems.json

# Load configuration and cache
if (Test-Path $ConfigFilePath) {
    $config = Get-Content $ConfigFilePath | ConvertFrom-Json
} else {
    Write-Error "Configuration file not found at $ConfigFilePath"
    exit 1
}

if (Test-Path $CacheFilePath) {
    $cache = Get-Content $CacheFilePath | ConvertFrom-Json
} else {
    Write-Error "Cache file not found at $CacheFilePath"
    exit 1
}

# Validate user input
function ValidateUserInput {
    param(
        [string]$ProblemNumber,
        [string]$ProblemLanguage,
        [array]$SupportedLanguages
    )

    if (-not ($ProblemNumber -match '^\d+$')) {
        Write-Host "❌ Problem number must be a positive integer." -ForegroundColor Red
        return $false
    }

    if ($ProblemNumber -match '^0\d+') {
    Write-Host "❌ Problem number should not have leading zeros (use 1 instead of 001)." -ForegroundColor Red
    return $false
    }

    if (-not ($SupportedLanguages -contains $ProblemLanguage)) {
        Write-Host "❌ Unsupported programming language. Supported languages are: $($SupportedLanguages -join ', ')." -ForegroundColor Red
        return $false
    }

    return $true
}

# Creating a new problem folder and copy the template
function CreateNewProblem {
    param(
        [string]$ProblemNumber,
        [string]$ProblemLanguage,
        [string]$TemplatePath,
        [string]$DestinationPath
    )

    $PaddedProblemNumber = $ProblemNumber.PadLeft(4, '0')

    $NewProblemDir = Join-Path $DestinationPath "$PaddedProblemNumber-$($cache.stat_status_pairs[$ProblemNumber - 1].stat.question__title_slug)"
    
    if (Test-Path $NewProblemDir) {
        Write-Host "❌ Problem directory already exists at $NewProblemDir" -ForegroundColor Red
        return
    }

    try {
        New-Item -ItemType Directory -Path $NewProblemDir | Out-Null
        Copy-Item -Path (Join-Path $TemplatePath "*") -Destination $NewProblemDir -Recurse
        Write-Host "✅ Successfully created new problem at $NewProblemDir" -ForegroundColor Green
    }
    catch {
        Write-Host "❌ Failed to create problem directory or copy template." -ForegroundColor Red
        Write-Host "   Error: $($_.Exception.Message)" -ForegroundColor DarkGray
    }
}

# Main execution
$Host.UI.RawUI.BackgroundColor = "Black"
$Host.UI.RawUI.ForegroundColor = "White"
Clear-Host

# Run the fetch data script to ensure we have the latest problem data
& $FetchDataScript

Write-Host ""
Write-Host "╔══════════════════════════════════════════════════════════════╗" -ForegroundColor Cyan
Write-Host "║                                                              ║" -ForegroundColor Cyan
Write-Host "║           " -NoNewline -ForegroundColor Cyan
Write-Host "🚀 LeetCode Collection Terminal 🚀" -NoNewline -ForegroundColor Yellow
Write-Host "                 ║" -ForegroundColor Cyan
Write-Host "║                                                              ║" -ForegroundColor Cyan
Write-Host "╚══════════════════════════════════════════════════════════════╝" -ForegroundColor Cyan
Write-Host ""

Write-Host "📚 Create a new LeetCode problem with ease!" -ForegroundColor Green
Write-Host ""

while ($true) {
    Write-Host "Problem Number (e.g., 1, 23): " -NoNewline -ForegroundColor Cyan
    $ProblemNumber = Read-Host

    Write-Host "Programming Language (e.g., csharp): " -NoNewline -ForegroundColor Cyan
    $ProblemLanguage = Read-Host

    if (ValidateUserInput -ProblemNumber $ProblemNumber -ProblemLanguage $ProblemLanguage -SupportedLanguages $config.supportedLanguages) {
        break
    }
    
    Write-Host ""
}

CreateNewProblem -ProblemNumber $ProblemNumber -ProblemLanguage $ProblemLanguage -TemplatePath $config.templatePath.$ProblemLanguage -DestinationPath $config.problemPath.$ProblemLanguage
