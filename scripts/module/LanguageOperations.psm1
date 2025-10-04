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
    <#
    .SYNOPSIS
    Updates problem template files for a specific language.
    
    .DESCRIPTION
    Delegates to language-specific template update functions.
    #>
    [CmdletBinding()]
    param(
        [string]$ProblemDirectory,
        [string]$Language,
        [PSCustomObject]$ProblemDetails
    )
    
    $functionName = "Update-$($Language)Template"
    
    if (Get-Command $functionName -ErrorAction SilentlyContinue) {
        & $functionName -ProblemDirectory $ProblemDirectory -Details $ProblemDetails
    }
    else {
        Write-Host "⚠️  No template processor found for language: $Language" -ForegroundColor Yellow
    }
}

function Invoke-LanguageTest {
    <#
    .SYNOPSIS
    Runs tests for a problem in a specific language.
    
    .DESCRIPTION
    Delegates to language-specific test runner functions.
    #>
    [CmdletBinding()]
    param(
        [string]$ProblemDirectory,
        [string]$Language
    )
    
    Write-Host ""
    Write-Host "🧪 Running tests for $Language..." -ForegroundColor Cyan
    Write-Host ""
    
    $functionName = "Invoke-$($Language)Test"
    
    if (Get-Command $functionName -ErrorAction SilentlyContinue) {
        return & $functionName -ProblemDirectory $ProblemDirectory
    }
    else {
        Write-Host "❌ No test runner configured for language: $Language" -ForegroundColor Red
        return $false
    }
}

function Test-LanguageEnvironment {
    <#
    .SYNOPSIS
    Validates that the environment for a specific language is properly set up.
    
    .DESCRIPTION
    Delegates to language-specific environment validation functions.
    #>
    [CmdletBinding()]
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