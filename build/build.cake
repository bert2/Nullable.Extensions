#addin Cake.Git
#tool GitVersion.CommandLine
#load prompt.cake
#load format-rel-notes.cake

var target = Argument("target", "Default");
var config = Argument("configuration", "Release");
var nugetKey = Argument<string>("nugetKey", null) ?? EnvironmentVariable("nuget_key");

var pkgName = "Nullable.Extensions";
var pkgDesc = "Nullable.Extensions is a set of extensions methods to help working with nullable types.";
var pkgTags = "nullable reference types; extensions; nrt; nrts; maybe monad; map; filter; bind";
var pkgAuthors = "Robert Hofmann";
var docUrl = "https://github.com/bert2/Nullable.Extensions";
var repoUrl = "https://github.com/bert2/Nullable.Extensions.git";

var rootDir = Directory("..");
var srcDir = rootDir + Directory("src");
var libDir = srcDir + Directory(pkgName);
var pkgDir = libDir + Directory($"bin/{config}");

var lastCommitMsg = EnvironmentVariable("APPVEYOR_REPO_COMMIT_MESSAGE") ?? GitLogTip(rootDir).MessageShort;
var lastCommitSha = EnvironmentVariable("APPVEYOR_REPO_COMMIT") ?? GitLogTip(rootDir).Sha;
var currBranch = GitBranchCurrent(rootDir).FriendlyName;
GitVersion semVer = null;

Task("SemVer").Does(() => {
    semVer = GitVersion();
    Information($"{semVer.FullSemVer} ({lastCommitMsg})");
});

Task("Clean").Does(() =>
    DotNetCoreClean(rootDir, new DotNetCoreCleanSettings {
        Configuration = config,
        Verbosity = DotNetCoreVerbosity.Minimal
    }));

Task("Build").Does(() =>
    DotNetCoreBuild(rootDir, new DotNetCoreBuildSettings {
        Configuration = config
    }));

Task("Test")
    .IsDependentOn("Build")
    .Does(() => DotNetCoreTest(rootDir, new DotNetCoreTestSettings {
        Configuration = config,
        NoBuild = true
    }));

Task("Pack")
    .IsDependentOn("SemVer")
    .Does(() => {
        var relNotes = FormatReleaseNotes(lastCommitMsg);
        Information($"Packing {semVer.NuGetVersion} ({relNotes})");

        var msbuildSettings = new DotNetCoreMSBuildSettings();
        msbuildSettings.Properties["PackageId"]                = new[] { pkgName };
        msbuildSettings.Properties["PackageVersion"]           = new[] { semVer.NuGetVersion };
        msbuildSettings.Properties["Title"]                    = new[] { pkgName };
        msbuildSettings.Properties["Description"]              = new[] { $"{pkgDesc}\r\n\r\nDocumentation: {docUrl}\r\n\r\nRelease notes: {relNotes}" };
        msbuildSettings.Properties["PackageTags"]              = new[] { pkgTags };
        msbuildSettings.Properties["PackageReleaseNotes"]      = new[] { relNotes };
        msbuildSettings.Properties["Authors"]                  = new[] { pkgAuthors };
        msbuildSettings.Properties["RepositoryUrl"]            = new[] { repoUrl };
        msbuildSettings.Properties["RepositoryCommit"]         = new[] { lastCommitSha };
        msbuildSettings.Properties["PackageLicenseExpression"] = new[] { "MIT" };
        msbuildSettings.Properties["IncludeSource"]            = new[] { "true" };
        msbuildSettings.Properties["IncludeSymbols"]           = new[] { "true" };
        msbuildSettings.Properties["SymbolPackageFormat"]      = new[] { "snupkg" };

        DotNetCorePack(libDir, new DotNetCorePackSettings {
            Configuration = config,
            OutputDirectory = pkgDir,
            NoBuild = true,
            NoDependencies = false,
            MSBuildSettings = msbuildSettings
        });
    });

Task("Release")
    .IsDependentOn("Pack")
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

RunTarget(target);
