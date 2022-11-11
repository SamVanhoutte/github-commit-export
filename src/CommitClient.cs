using Flurl;
using Flurl.Http;

namespace GithubWorkReport;

public class CommitClient
{
    public static async Task<List<GitCommit>> GetCommitsAsync(GithubSettings githubSettings, string userName)
    {
        var commits = new List<GitCommit> { };
        var commitsLeft = true;
        var page = 1;
        while (commitsLeft)
        {
            var commitUrl = githubSettings.BaseUri
                .AppendPathSegment("repos")
                .AppendPathSegment(githubSettings.Owner)
                .AppendPathSegment(githubSettings.Repo)
                .AppendPathSegment("commits")
                .SetQueryParam("author", userName)
                .SetQueryParam("page", page)
                .SetQueryParam("per_page", 100);
            var response = await commitUrl
                .WithBasicAuth(githubSettings.UserName, githubSettings.Pat)
                .WithHeaders(new
                {
                    User_Agent = "PostmanRuntime/7.29.2",
                })
                .GetAsync();
            if (response.StatusCode < 300)
            {
                commitsLeft = response.Headers.Contains("Link");
                var pageCommits = await response.GetJsonAsync<IEnumerable<GitCommit>>();
                commitsLeft = pageCommits.Any();
                commits.AddRange(pageCommits);
            }
            else
            {
                Console.WriteLine($"Response with {response.StatusCode} received");
                break;
            } 
            page++;
        }

        return commits.ToList();
    }
}