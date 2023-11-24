namespace Domain.Entities;

public class Flag : BaseEntity
{
    public required string PackageVersion { get; set; }
    public required string Key { get; set; }
    public required string Situation { get; set; }

    public virtual required IList<EarlyBird> EarlyBirds { get; set; }
    public virtual required IList<Changes> Changes { get; set; }
}
