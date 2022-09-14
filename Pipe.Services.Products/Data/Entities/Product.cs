using Domain.Entities.Base;

namespace Products.Data.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImageURL { get; set; }
}