# Script to fetch all LeetCode problems from the official API
# Uses caching to avoid unnecessary API calls

# ============================================================================
# GLOBAL VARIABLES
# ============================================================================
$script:CacheDirectory = Join-Path $PSScriptRoot .. cache
$script:CachePath = Join-Path $script:CacheDirectory problems.json
$script:CacheExpirationHours = 24  # Cache expires after 24 hours

# ============================================================================
# FUNCTIONS
# ============================================================================

function Test-CacheValid {
    <#
    .SYNOPSIS
    Checks if the cache file is valid and not expired.
    #>
    param([string]$CachePath)
    
    if (-not (Test-Path $CachePath)) {
        return $false
    }
    
    $cacheFile = Get-Item $CachePath
    $cacheAge = (Get-Date) - $cacheFile.LastWriteTime
    
    if ($cacheAge.TotalHours -gt $script:CacheExpirationHours) {
        return $false
    }
    
    return $true
}

function Get-LeetCodeProblems {
    <#
    .SYNOPSIS
    Fetches all problems from the LeetCode API.
    
    .DESCRIPTION
    Connects to the LeetCode API and retrieves all available problems.
    Returns the problem data or null if the request fails.
    #>
    [CmdletBinding()]
    param()
    
    $apiUrl = "https://leetcode.com/api/problems/all/"
    
    try {
        Write-Host "📡 Connecting to LeetCode API..." -ForegroundColor Cyan
        $response = Invoke-RestMethod -Uri $apiUrl -Method Get -TimeoutSec 30
        
        if ($response -and $response.stat_status_pairs) {
            Write-Host "✅ Successfully fetched " -NoNewline -ForegroundColor Green
            Write-Host "$($response.stat_status_pairs.Count)" -NoNewline -ForegroundColor Yellow
            Write-Host " problems!" -ForegroundColor Green
            return $response
        } else {
            Write-Host "⚠️  API returned unexpected data format" -ForegroundColor Yellow
            return $null
        }
    }
    catch {
        Write-Host "❌ Failed to fetch data from LeetCode API" -ForegroundColor Red
        Write-Host "   Error: $($_.Exception.Message)" -ForegroundColor DarkGray
        return $null
    }
}

# ============================================================================
# MAIN EXECUTION
# ============================================================================

# Set console colors
$Host.UI.RawUI.BackgroundColor = "Black"
$Host.UI.RawUI.ForegroundColor = "White"

Write-Host ""
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
Write-Host "  🔍 LeetCode Problem Data Fetcher" -ForegroundColor Cyan
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
Write-Host ""

# Ensure cache directory exists
if (-not (Test-Path $script:CacheDirectory)) {
    Write-Host "📁 Creating cache directory..." -ForegroundColor Yellow
    New-Item -ItemType Directory -Path $script:CacheDirectory -Force | Out-Null
}

# Check if cache is valid
if (Test-CacheValid -CachePath $script:CachePath) {
    $cacheFile = Get-Item $script:CachePath
    $cacheAge = [Math]::Round(((Get-Date) - $cacheFile.LastWriteTime).TotalHours, 1)
    
    Write-Host "✨ Using cached data " -NoNewline -ForegroundColor Green
    Write-Host "($cacheAge hours old)" -ForegroundColor DarkGray
    Write-Host "   Cache expires in " -NoNewline -ForegroundColor DarkGray
    Write-Host "$([Math]::Round($script:CacheExpirationHours - $cacheAge, 1)) hours" -ForegroundColor Yellow
} else {
    if (Test-Path $script:CachePath) {
        Write-Host "⏰ Cache expired, fetching fresh data..." -ForegroundColor Yellow
    } else {
        Write-Host "📭 No cache found, fetching data..." -ForegroundColor Yellow
    }
    
    Write-Host ""
    
    # Fetch from API
    $problemData = Get-LeetCodeProblems
    
    if ($problemData) {
        # Save to cache
        Write-Host "💾 Saving to cache..." -ForegroundColor Cyan
        $problemData | ConvertTo-Json -Depth 10 | Set-Content -Path $script:CachePath -Encoding UTF8
        Write-Host "✅ Cache updated successfully!" -ForegroundColor Green
    } else {
        Write-Host "⚠️  Failed to fetch data. Using existing cache if available." -ForegroundColor Yellow
        
        if (-not (Test-Path $script:CachePath)) {
            Write-Host "❌ No cache available. Please check your internet connection and try again." -ForegroundColor Red
            exit 1
        }
    }
}

Write-Host ""
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
Write-Host ""

