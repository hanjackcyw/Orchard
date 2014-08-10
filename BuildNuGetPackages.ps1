$dotNetFolderName = "net45"
$outputDirectory = "build/NuGet"
Set-Alias nuget src/.nuget/nuget

nuget update -self

If (Test-Path "$outputDirectory"){
	rmdir "$outputDirectory" -Force -Recurse
}
mkdir "$outputDirectory"

# Orchard.Libraries
mkdir Orchard.Libraries/Libraries
copy lib/* Orchard.Libraries/Libraries -Recurse
move Orchard.Libraries/Libraries/Orchard.Libraries.nuspec Orchard.Libraries/Orchard.Libraries.nuspec
mkdir Orchard.Libraries/tools
move Orchard.Libraries/Libraries/init.ps1 Orchard.Libraries/tools/init.ps1
rm Orchard.Libraries.*.nupkg
nuget pack Orchard.Libraries/Orchard.Libraries.nuspec -OutputDirectory "$outputDirectory" -NoPackageAnalysis
rmdir Orchard.Libraries -Force -Recurse

# Orchard.Framework
nuget pack src/Orchard/Orchard.Framework.csproj -IncludeReferencedProjects -Build -Prop Configuration=Release -OutputDirectory "$outputDirectory"