using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Changes : BaseEntity
{
    public required string Key { get; set; }
    public required string AttributeChanged { get; set; }
    public required string CurrentSituation { get; set; }
    public required string LastSituation { get; set; }
    public Guid IdFlag { get; private set; }

    [ForeignKey("IdFlag")]
    public virtual required Flag Flag { get; set; }
}
