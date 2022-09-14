namespace Domain.Dto.Base;

public abstract class BaseEntityDto : IBaseEntityDto
{
    public Guid? Id { get; set; }
}