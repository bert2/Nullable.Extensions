#tool nuget:?package=GitVersion.CommandLine&version=5.6.3
#tool Codecov
#addin Cake.Codecov
#addin Cake.Git
#load prompt.cake
#load format-rel-notes.cake

var target = Argument("target", "Default");
var config = Argument("configuration", "Release");
var nugetKey = Argument<string>("nugetKey", null) ?? EnvironmentVariable("nuget_key");

var rootDir = Directory("..");
var srcDir = rootDir + Directory("src");
var testDir = rootDir + Directory("tests");

var lastCommitMsg = EnvironmentVariable("APPVEYOR_REPO_COMMIT_MESSAGE") ?? GitLogTip(rootDir).MessageShort;
var lastCommitSha = EnvironmentVariable("APPVEYOR_REPO_COMMIT") ?? GitLogTip(rootDir).Sha;
var currBranch = GitBranchCurrent(rootDir).FriendlyName;
GitVersion semVer = null;

Task("SemVer")
    .Does(() => {
        semVer = GitVersion();
        Information($"{semVer.FullSemVer} ({lastCommitMsg})");
    });

Task("Clean")
    .Does(() =>
        DotNetCoreClean(rootDir, new DotNetCoreCleanSettings {
            Configuration = config,
            Verbosity = DotNetCoreVerbosity.Minimal
        }));

Task("Build")
    .IsDependentOn("SemVer")
    .Does(() =>
        DotNetCoreBuild(rootDir, new DotNetCoreBuildSettings {
            Configuration = config,
            MSBuildSettings = new DotNetCoreMSBuildSettings()
                .SetVersion(semVer.AssemblySemVer)
        }));

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
        DotNetCoreTest(rootDir, new DotNetCoreTestSettings {
            Configuration = config,
            NoBuild = true,
            ArgumentCustomization = args => {
                var msbuildSettings = new DotNetCoreMSBuildSettings()
                    .WithProperty("CollectCoverage", new[] { "true" })
                    .WithProperty("CoverletOutputFormat", new[] { "opencover" });
                args.AppendMSBuildSettings(msbuildSettings, environment: null);
                return args;
            }
        }));

Task("UploadCoverage")
    .Does(() =>
        Codecov(testDir + File("UnitTests/coverage.opencover.xml")));

Task("Pack-Nullable.Extensions")
    .IsDependentOn("SemVer")
    .Does(() => {
        var relNotes = FormatReleaseNotes(lastCommitMsg);
        Information($"Packing {semVer.NuGetVersion} ({relNotes})");

        var pkgName = "Nullable.Extensions";
        var pkgDesc = "A set of extensions methods to help working with nullable types by implementing the Maybe monad on top of `T?`.";
        var pkgTags = "nullable reference types; extensions; nrt; nrts; maybe monad; maybe functor; map; filter; bind";
        var pkgAuthors = "Robert Hofmann";
        var docUrl = "https://github.com/bert2/Nullable.Extensions";
        var repoUrl = "https://github.com/bert2/Nullable.Extensions.git";
        var libDir = srcDir + Directory(pkgName);
        var pkgDir = libDir + Directory($"bin/{config}");

        var msbuildSettings = new DotNetCoreMSBuildSettings()
        	.WithProperty("PackageId",                new[] { pkgName })
        	.WithProperty("PackageVersion",           new[] { semVer.NuGetVersion })
        	.WithProperty("Title",                    new[] { pkgName })
        	.WithProperty("Description",              new[] { $"{pkgDesc}\r\n\r\nDocumentation: {docUrl}\r\n\r\nRelease notes: {relNotes}" })
        	.WithProperty("PackageTags",              new[] { pkgTags })
        	.WithProperty("PackageReleaseNotes",      new[] { relNotes })
        	.WithProperty("Authors",                  new[] { pkgAuthors })
        	.WithProperty("RepositoryUrl",            new[] { repoUrl })
        	.WithProperty("RepositoryCommit",         new[] { lastCommitSha })
        	.WithProperty("PackageLicenseExpression", new[] { "MIT" })
        	.WithProperty("IncludeSource",            new[] { "true" })
        	.WithProperty("IncludeSymbols",           new[] { "true" })
        	.WithProperty("SymbolPackageFormat",      new[] { "snupkg" });

        DotNetCorePack(libDir, new DotNetCorePackSettings {
            Configuration = config,
            OutputDirectory = pkgDir,
            NoBuild = true,
            NoDependencies = false,
            MSBuildSettings = msbuildSettings
        });
    });

Task("Release-Nullable.Extensions")
    .IsDependentOn("Pack-Nullable.Extensions")
    .Does(() => {
        if (currBranch != "master") {
            Information($"Will not release package built from branch '{currBranch}'.");
            return;
        }

        if (lastCommitMsg.Contains("without release")) {
            Information($"Skipping release to nuget.org");
            return;
        }

        Information($"Releasing {semVer.NuGetVersion} to nuget.org");

        if (string.IsNullOrEmpty(nugetKey))
            nugetKey = Prompt("Enter nuget API key: ");

        var pkgName = "Nullable.Extensions";
        var libDir = srcDir + Directory(pkgName);
        var pkgDir = libDir + Directory($"bin/{config}");

        DotNetCoreNuGetPush(
            pkgDir + File($"{pkgName}.{semVer.NuGetVersion}.nupkg"),
            new DotNetCoreNuGetPushSettings {
                Source = "nuget.org",
                ApiKey = nugetKey
            });
    });

Task("Default")
    .IsDependentOn("SemVer")
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .IsDependentOn("Test");

Task("Release")
    .IsDependentOn("UploadCoverage")
    .IsDependentOn("Release-Nullable.Extensions");

RunTarget(target);
