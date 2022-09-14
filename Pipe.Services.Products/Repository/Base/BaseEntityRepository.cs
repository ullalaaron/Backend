using AutoMapper;
using Domain.Dto.Base;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Products.Data;

namespace Products.Repository.Base;

public abstract class BaseEntityRepository<T, TDto> : IBaseEntityRepository<T, TDto>
    where T : class, IBaseEntity
    where TDto : class, IBaseEntityDto
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    protected BaseEntityRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync(CancellationToken ct)
    {
        var res = await _dbContext.Set<T>().ToListAsync(ct);
        return _mapper.Map<IEnumerable<TDto>>(res);
    }

    public async Task<TDto> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var res = await _dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id, ct);
        return _mapper.Map<TDto>(res);
    }

    public async Task<TDto> UpsertAsync(TDto updateDto, CancellationToken ct)
    {
        var entity = _mapper.Map<TDto, T>(updateDto);
        if (updateDto.Id != null)
        {
            _dbContext.Set<T>().Update(entity);

        }
        else
        {
            _dbContext.Set<T>().Add(entity);
        }

        await _dbContext.SaveChangesAsync(ct);
        return _mapper.Map<T, TDto>(entity);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
    {
        var res = await _dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id, ct);
        if (res == null)
        {
            throw new Exception("Entity not found");
        }
        
        _dbContext.Set<T>().Remove(res);
        await _dbContext.SaveChangesAsync(ct);
        return true;
    }
}