public partial class Branch
{
    public string name { get; set; }
    public Commit commit { get; set; }
    public bool Protected { get; set; }
    public Protection Protection { get; set; }
    public Uri ProtectionUrl { get; set; }
}

public partial class Protection
{
    public bool Enabled { get; set; }
    public RequiredStatusChecks RequiredStatusChecks { get; set; }
}

public partial class RequiredStatusChecks
{
    public EnforcementLevel EnforcementLevel { get; set; }
    public List<object> Contexts { get; set; }
    public List<object> Checks { get; set; }
}

public enum EnforcementLevel { Everyone, Off };