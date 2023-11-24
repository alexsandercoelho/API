using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Feature : BaseEntity
{
    public Guid IdProfile { get; private set; }

    [ForeignKey("IdProfile")]
    public virtual required Profiles Profile { get; set; }
}
