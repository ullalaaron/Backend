using AutoMapper;
using Products.Data;
using Products.Data.Entities;
using Products.Dto;
using Products.Repository.Base;

namespace Products.Repository;

public class ProductRepository : BaseEntityRepository<Product, ProductDto>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
}