
namespace Domain.Entities.Base;

public abstract class BaseEntity : IBaseEntity
{
    public Guid? Id { get; set; }
}