namespace Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow.ToLocalTime();

    public override bool Equals(object obj)
    {
        var compareTo = obj as BaseEntity;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(BaseEntity a, BaseEntity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(BaseEntity a, BaseEntity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return GetType().Name + " [Id=" + Id + "]";
    }
}
