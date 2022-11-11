using Flurl;
using Flurl.Http;

namespace GithubWorkReport;

public class BranchClient
{
    public static async Task<List<Branch>> GetBranchesAsync(GithubSettings githubSettings)
    {
        var branchUrl = githubSettings.BaseUri
            .AppendPathSegment("repos")
            .AppendPathSegment(githubSettings.Owner)
            .AppendPathSegment(githubSettings.Repo)
            .AppendPathSegment("branches")
            .SetQueryParam("per_page", 100);
        Console.WriteLine(branchUrl);
        var branches = await branchUrl
            .WithBasicAuth(githubSettings.UserName, githubSettings.Pat)
            .WithHeaders(new
            {
                User_Agent = "PostmanRuntime/7.29.2",
            })
            .GetJsonAsync<IEnumerable<Branch>>();
        return branches.ToList();
    }
}