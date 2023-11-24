using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class EarlyBird : BaseEntity
{
    public int QtyPeople { get; set; }
    public required string ComparisionProperty { get; set; }
    public Guid IdFlag { get; private set; }

    [ForeignKey("IdFlag")]
    public virtual required Flag Flag { get; set; }
}
