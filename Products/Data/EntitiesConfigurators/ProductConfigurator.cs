using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Data.Entities;
using Products.Data.EntitiesConfigurators.Base;

namespace Products.Data.EntitiesConfigurators;

public class ProductConfigurator : BaseEntityConfigurator<Product>
{
    protected override void Configure(EntityTypeBuilder<Product> builder, DbContext context)
    {
        builder.Property(e => e.Price).HasPrecision(2);
    }
}