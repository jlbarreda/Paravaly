var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var projectDir = Directory("./src/Paravaly");
var testsDir = Directory("./test/Paravaly.Tests");
var outputDir = Directory("./artifacts");
var project = File("Paravaly.csproj");
var testProject = File("Paravaly.Tests.csproj");

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

Task("Build")
	.IsDependentOn("Clean")
	.Does(() =>
	{
		var settings = new DotNetCoreBuildSettings
		{
			Configuration = configuration
		};

		DotNetCoreBuild(projectDir + project, settings);
		DotNetCoreBuild(testsDir + testProject, settings);
	});

Task("Test")
	.IsDependentOn("Build")
	.Does(() =>
	{
			DotNetCoreTest(testsDir + testProject);
	});

Task("Pack")
	.IsDependentOn("Test")
	.Does(() =>
	{
		var settings = new DotNetCorePackSettings
		{
			OutputDirectory = outputDir,
			NoBuild = false
		};

		DotNetCorePack(projectDir + project, settings);

		if (AppVeyor.IsRunningOnAppVeyor)
		{
			foreach (var file in GetFiles(outputDir.Path.FullPath + "/**/*"))
			{
				AppVeyor.UploadArtifact(file.FullPath);
			}
		}
	});

Task("Default")
	.IsDependentOn("Pack");

RunTarget(target);