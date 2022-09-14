using Domain.Dto.Base;

namespace Pipe.Web.API.Services.Base;

public interface IApiService<TDto>
    where TDto : BaseEntityDto, new()
{
    Task<IEnumerable<TDto>> GetAllAsync(CancellationToken ct);
    Task<TDto> GetByIdAsync(Guid id, CancellationToken ct);
    Task<TDto> UpsertAsync(TDto dto, CancellationToken ct);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct);
    Task<T> SendRequestAsync<T>(HttpMethod method, string url, Object? data, CancellationToken ct);
}