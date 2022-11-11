    public partial class GitCommit
    {
        public string Sha { get; set; }
        public string NodeId { get; set; }
        public Commit commit { get; set; }
        public Uri Url { get; set; }
        public Uri HtmlUrl { get; set; }
        public Uri CommentsUrl { get; set; }
        public GitCommitAuthor author { get; set; }
        public GitCommitAuthor committer { get; set; }
        public List<Parent> Parents { get; set; }
    }

    public partial class GitCommitAuthor
    {
        public string login { get; set; }
        public long Id { get; set; }
        public string NodeId { get; set; }
        public Uri AvatarUrl { get; set; }
        public string GravatarId { get; set; }
        public Uri Url { get; set; }
        public Uri HtmlUrl { get; set; }
        public Uri FollowersUrl { get; set; }
        public string FollowingUrl { get; set; }
        public string GistsUrl { get; set; }
        public string StarredUrl { get; set; }
        public Uri SubscriptionsUrl { get; set; }
        public Uri OrganizationsUrl { get; set; }
        public Uri ReposUrl { get; set; }
        public string EventsUrl { get; set; }
        public Uri ReceivedEventsUrl { get; set; }
        public string Type { get; set; }
        public bool SiteAdmin { get; set; }
    }

    public partial class Commit
    {
        public CommitAuthor author { get; set; }
        public CommitAuthor Committer { get; set; }
        public string message { get; set; }
        public Tree Tree { get; set; }
        public Uri Url { get; set; }
        public long CommentCount { get; set; }
        public Verification Verification { get; set; }
    }

    public partial class CommitAuthor
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTimeOffset date { get; set; }
    }

    public partial class Tree
    {
        public string Sha { get; set; }
        public Uri Url { get; set; }
    }

    public partial class Verification
    {
        public bool Verified { get; set; }
        public string Reason { get; set; }
        public string Signature { get; set; }
        public string Payload { get; set; }
    }

    public partial class Parent
    {
        public string Sha { get; set; }
        public Uri Url { get; set; }
        public Uri HtmlUrl { get; set; }
    }