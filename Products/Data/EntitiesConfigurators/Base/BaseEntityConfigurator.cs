using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Data.Entities.Base;

namespace Products.Data.EntitiesConfigurators.Base;

public abstract class BaseEntityConfigurator<TEntity> where TEntity : class, IBaseEntity
{
    protected Expression<Func<TEntity, object>> KeyExpression { get; } = (entity => entity.Id); 

    public ModelBuilder ModelBuilder { get; private set; }

    public void Configure(ModelBuilder modelBuilder, DbContext context)
    {
        ModelBuilder = modelBuilder;
        EntityTypeBuilder<TEntity> builder = modelBuilder.Entity<TEntity>();
        builder.HasKey(KeyExpression!);
        Configure(builder, context);
    }

    protected abstract void Configure(EntityTypeBuilder<TEntity> builder, DbContext context);
}