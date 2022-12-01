param([Parameter(Mandatory=$true)][string]$version,
	  [Parameter(Mandatory=$true)][bool]$incrementPackageVersion)

cd .\Scaffolding\AoC.Core\

if ($incrementPackageVersion) {
	dotnet pack -p:Version=$($version)
	nuget add .\bin\Debug\AoC.Core.$($version).nupkg -source C:\Users\reube\source\feeds\NuGet

	Write-Host "AoC.Core version $($version) has been added to the feed!" -ForegroundColor Green
}

cd ..\working\templates\day\

if (Test-Path -Path .\bin) {
    rmdir .\bin
    rmdir .\obj
}

dotnet new install .\ --force

Write-Host "Template has been published!" -ForegroundColor Green

cd ..\..\..\..