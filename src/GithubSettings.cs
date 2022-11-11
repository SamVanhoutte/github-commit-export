namespace GithubWorkReport;

public class GithubSettings
{
    public string BaseUri => "https://api.github.com";
    public string Owner { get; set; }
    public string Repo { get; set; }
    public string Pat { get; set; }
    public string UserName { get; set; }
}