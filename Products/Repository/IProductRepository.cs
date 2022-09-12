using Products.Data.Entities;
using Products.Dto;
using Products.Repository.Base;

namespace Products.Repository;

public interface IProductRepository : IBaseEntityRepository<Product, ProductDto> { }