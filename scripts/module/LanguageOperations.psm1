# Main orchestrator for language-specific operations.

#Requires -Version 5.1

# ============================================================================
# MODULE IMPORTS
# ============================================================================

$languagesPath = Join-Path $PSScriptRoot "languages"

# Dynamically load all language modules
Get-ChildItem -Path $languagesPath -Filter "*.psm1" | ForEach-Object {
    Import-Module $_.FullName -Force
}

# ============================================================================
# PUBLIC FUNCTIONS
# ============================================================================

function Update-ProblemTemplate {
    param(
        [string]$ProblemPath,
        [string]$Language,
        [PSCustomObject]$ProblemDetails
    )
    
    $functionName = "Update-$($Language)Template"
    
    if (Get-Command $functionName -ErrorAction SilentlyContinue) {
        & $functionName -ProblemPath $ProblemPath -Details $ProblemDetails
    }
    else {
        Write-Host "⚠️  No template processor found for language: $Language" -ForegroundColor Yellow
    }
}

function Invoke-LanguageTest {
    param(
        [string]$ProblemPath,
        [string]$Language
    )
    
    Write-Host ""
    Write-Host "🧪 Running tests for $Language..." -ForegroundColor Cyan
    Write-Host ""
    
    $functionName = "Invoke-$($Language)Test"
    
    if (Get-Command $functionName -ErrorAction SilentlyContinue) {
        return & $functionName -ProblemPath $ProblemPath
    }
    else {
        Write-Host "❌ No test runner configured for language: $Language" -ForegroundColor Red
        return $false
    }
}

function Test-LanguageEnvironment {
    param([string]$Language)
    
    $functionName = "Test-$($Language)Environment"
    
    if (Get-Command $functionName -ErrorAction SilentlyContinue) {
        return & $functionName
    }
    else {
        # If no validator exists, assume environment is OK
        return $true
    }
}

# ============================================================================
# EXPORTS
# ============================================================================

Export-ModuleMember -Function @(
    'Update-ProblemTemplate',
    'Invoke-LanguageTest',
    'Test-LanguageEnvironment'
)