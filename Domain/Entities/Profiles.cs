namespace Domain.Entities;

public class Profiles : BaseEntity
{
    public virtual required IList<Person> Persons { get; set; }
    public virtual required IList<Feature> Features { get; set; }
}
