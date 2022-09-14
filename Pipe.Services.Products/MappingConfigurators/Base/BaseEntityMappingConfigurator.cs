using AutoMapper;
using Domain.Dto.Base;
using Domain.Entities.Base;

namespace Products.MappingConfigurators.Base;

public abstract class BaseEntityMappingConfigurator<TEntity, TDto> : Profile
    where TEntity : class, IBaseEntity
    where TDto : class, IBaseEntityDto
{
    protected BaseEntityMappingConfigurator()
    {
        var entityDtoMap = CreateMap<TEntity, TDto>();
        ConfigureExpressionInternal(entityDtoMap);
        var dtoEntityMap = CreateMap<TDto, TEntity>();
        ConfigureExpressionInternal(dtoEntityMap);
    }

    protected void ConfigureExpressionInternal(IMappingExpression<TEntity, TDto> expression)
    {
        ConfigureExpression(expression);
    }
    protected void ConfigureExpressionInternal(IMappingExpression<TDto, TEntity> expression)
    {
        ConfigureExpression(expression);
    }
    protected virtual void ConfigureExpression(IMappingExpression<TEntity, TDto> expression) { }

    protected virtual void ConfigureExpression(IMappingExpression<TDto, TEntity> expression) { }
}