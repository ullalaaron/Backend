using Products.Data.Entities.Base;
using Products.Dto.Base;

namespace Products.Repository.Base;

public interface IBaseEntityRepository<T, TDto>
    where T : class, IBaseEntity
    where TDto : class, IBaseEntityDto
{
    Task<IEnumerable<TDto>> GetAllAsync(CancellationToken ct);
    Task<TDto> GetByIdAsync(Guid id, CancellationToken ct);
    Task<TDto> UpsertAsync(TDto updateDto, CancellationToken ct);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct);
}