# Script to fetch all LeetCode problems from the official API
# Uses caching to avoid unnecessary API calls

# ============================================================================
# GLOBAL VARIABLES
# ============================================================================
$CacheDir = Join-Path $PSScriptRoot .. cache
$CacheFilePath = Join-Path $CacheDir problems.json
$CacheExpirationHours = 24  # Cache expires after 24 hours

# ============================================================================
# FUNCTIONS
# ============================================================================
# Check if cache is valid
function Test-CacheValid {
    param([string]$CachePath)
    
    if (-not (Test-Path $CachePath)) {
        return $false
    }
    
    $cacheFile = Get-Item $CachePath
    $cacheAge = (Get-Date) - $cacheFile.LastWriteTime
    
    if ($cacheAge.TotalHours -gt $CacheExpirationHours) {
        return $false
    }
    
    return $true
}

# Fetch problems from LeetCode API
function Get-LeetCodeProblems {
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
if (-not (Test-Path $CacheDir)) {
    Write-Host "📁 Creating cache directory..." -ForegroundColor Yellow
    New-Item -ItemType Directory -Path $CacheDir -Force | Out-Null
}

# Check if cache is valid
if (Test-CacheValid -CachePath $CacheFilePath) {
    $cacheFile = Get-Item $CacheFilePath
    $cacheAge = [Math]::Round(((Get-Date) - $cacheFile.LastWriteTime).TotalHours, 1)
    
    Write-Host "✨ Using cached data " -NoNewline -ForegroundColor Green
    Write-Host "($cacheAge hours old)" -ForegroundColor DarkGray
    Write-Host "   Cache expires in " -NoNewline -ForegroundColor DarkGray
    Write-Host "$([Math]::Round($CacheExpirationHours - $cacheAge, 1)) hours" -ForegroundColor Yellow
} else {
    if (Test-Path $CacheFilePath) {
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
        $problemData | ConvertTo-Json -Depth 10 | Set-Content -Path $CacheFilePath -Encoding UTF8
        Write-Host "✅ Cache updated successfully!" -ForegroundColor Green
    } else {
        Write-Host "⚠️  Failed to fetch data. Using existing cache if available." -ForegroundColor Yellow
        
        if (-not (Test-Path $CacheFilePath)) {
            Write-Host "❌ No cache available. Please check your internet connection and try again." -ForegroundColor Red
            exit 1
        }
    }
}

Write-Host ""
Write-Host "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━" -ForegroundColor DarkGray
Write-Host ""

