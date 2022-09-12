using Products.Dto.Base;

namespace Products.Dto;

public class ProductDto : BaseEntityDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImageURL { get; set; }
}