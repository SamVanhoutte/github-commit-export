using System.Text;
using Flurl;
using Flurl.Http;
using GithubWorkReport;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NullValueHandling = Flurl.NullValueHandling;

var cfgBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.json", true, false)
    .AddJsonFile($"appsettings.dev.json", true, false)
    .AddJsonFile($"local.settings.json", true, false)
    .AddEnvironmentVariables();

var configuration = cfgBuilder.Build();
var githubSettings = new GithubSettings();
configuration.Bind("Github", githubSettings);

if (string.IsNullOrWhiteSpace(githubSettings.Owner))
{
    Console.WriteLine("Github settings were not provided");
    return;
}

try
{
    var builder = new StringBuilder();
    //var branches = await BranchClient.GetBranchesAsync(githubSettings);
    var commits = await CommitClient.GetCommitsAsync(githubSettings, githubSettings.UserName);
    foreach (var gitCommit in commits.Where(c=>!c.commit.message.StartsWith("merge", StringComparison.CurrentCultureIgnoreCase)))
    {
        Console.WriteLine($"{gitCommit.commit?.author.date.ToString("d")} - {gitCommit.author?.login}: {gitCommit.commit.message}");
        builder.AppendLine($"\"{gitCommit.commit.author.date.ToString("d")}\",\"{gitCommit.commit.message}\"");
    }
    File.WriteAllText("commits.csv", builder.ToString());
}
catch (Exception e)
{
    Console.WriteLine(e);
}