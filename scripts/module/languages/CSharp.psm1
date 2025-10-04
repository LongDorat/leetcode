# Csharp specific operations for LeetCode problems

#Requires -Version 5.1

# ============================================================================
# FUNCTIONS
# ============================================================================

function Update-csharpTemplate {
    param(
        [string]$ProblemPath,
        [PSCustomObject]$Details
    )

    $titleWithoutSpaces = $Details.question__title -replace '\s+', ''
    
    Write-Host "  🔄 Processing C# template files..." -ForegroundColor Cyan
    
    $problemFiles = Get-ChildItem -Path $ProblemPath -File
    $renamedFiles = @()
    
    foreach ($file in $problemFiles) {
        try {
            # Update file content
            $content = Get-Content $file.FullName -Raw
            $updatedContent = $content -replace 'Template', $titleWithoutSpaces
            
            # Only write if content changed
            if ($content -ne $updatedContent) {
                Set-Content -Path $file.FullName -Value $updatedContent -Encoding UTF8
                Write-Host "     ✓ Updated content: $($file.Name)" -ForegroundColor Green
            }
            
            # Rename file if needed
            if ($file.Name -like "*Template*") {
                $newFileName = $file.Name -replace 'Template', $titleWithoutSpaces
                
                Rename-Item -Path $file.FullName -NewName $newFileName -Force
                
                Write-Host "     ✓ Renamed: $($file.Name) → $newFileName" -ForegroundColor Cyan
                $renamedFiles += $newFileName
            }
        }
        catch {
            Write-Host "     ✗ Error processing $($file.Name): $($_.Exception.Message)" -ForegroundColor Red
        }
    }
    
    Write-Host ""
    Write-Host "✅ C# template processing complete!" -ForegroundColor Green
    if ($renamedFiles.Count -gt 0) {
        Write-Host "   Renamed $($renamedFiles.Count) file(s)" -ForegroundColor DarkGray
    }
    
    # Add to solution
    Write-Host ""
    Write-Host "➕ Adding project to solution..." -ForegroundColor Cyan
    
    $solutionPath = Join-Path $ProblemPath ".." "LeetCode.slnx"
    $csprojFile = Join-Path $ProblemPath "$titleWithoutSpaces.csproj"
    
    if (Test-Path $csprojFile) {
        dotnet sln $solutionPath add $csprojFile 2>&1 | Out-Null
        
        if ($LASTEXITCODE -eq 0) {
            Write-Host "   ✅ Successfully added to solution!" -ForegroundColor Green
        } else {
            Write-Host "   ⚠️  Failed to add to solution" -ForegroundColor Yellow
        }
    } else {
        Write-Host "   ⚠️  .csproj file not found: $titleWithoutSpaces.csproj" -ForegroundColor Yellow
    }
}

function Remove-CSharpProjectFromSolution {
    param(
        [string]$ProblemPath,
        [string]$TitleWithoutSpaces
    )
    
    Write-Host ""
    Write-Host "➖ Removing project from solution..." -ForegroundColor Cyan
    
    $solutionPath = Join-Path $ProblemPath ".." "LeetCode.slnx"
    $csprojFile = Join-Path $ProblemPath "$TitleWithoutSpaces.csproj"
    
    dotnet sln $solutionPath remove $csprojFile 2>&1 | Out-Null
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "   ✅ Successfully removed from solution!" -ForegroundColor Green
    } else {
        Write-Host "   ⚠️  Failed to remove from solution" -ForegroundColor Yellow
    }
}

# ============================================================================
# EXPORTS
# ============================================================================

Export-ModuleMember -Function @(
    'Update-csharpTemplate',
    'Remove-CSharpProjectFromSolution'
)