var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var projectDir = Directory("./src/Paravaly");
var testsDir = Directory("./test/Paravaly.Tests");
var outputDir = Directory("./artifacts");
var projectJson = File("project.json");

Task("Clean")
	.Does(() =>
	{
		CleanDirectories(new DirectoryPath[] {
			projectDir + Directory("bin") + Directory(configuration),
			projectDir + Directory("obj") + Directory(configuration),
			testsDir + Directory("bin") + Directory(configuration),
			testsDir + Directory("obj") + Directory(configuration),
			outputDir
		});

		if (DirectoryExists(outputDir))
		{
			DeleteDirectory(outputDir, recursive: false);
		}
	});

Task("Restore")
	.IsDependentOn("Clean")
	.Does(() =>
	{
		DotNetCoreRestore();
	});

Task("Build")
	.IsDependentOn("Restore")
	.Does(() =>
	{
		var settings = new DotNetCoreBuildSettings
		{
			Configuration = configuration
		};

		DotNetCoreBuild(projectDir + projectJson, settings);
		DotNetCoreBuild(testsDir + projectJson, settings);
	});

Task("Test")
	.IsDependentOn("Build")
	.Does(() =>
	{
			DotNetCoreTest(testsDir);
	});

Task("Pack")
	.IsDependentOn("Test")
	.Does(() =>
	{
		var settings = new DotNetCorePackSettings
		{
			OutputDirectory = outputDir,
			NoBuild = true
		};

		DotNetCorePack(projectDir + projectJson, settings);

		if (AppVeyor.IsRunningOnAppVeyor)
		{
			foreach (var file in GetFiles(outputDir + Directory("**/*")))
			{
				AppVeyor.UploadArtifact(file.FullPath);
			}
		}
	});

Task("Default")
	.IsDependentOn("Pack");

RunTarget(target);