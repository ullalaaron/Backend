

using Domain.Dto.Base;

namespace Pipe.Web.API.Dto;

public class ProductDto : BaseEntityDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string ImageURL { get; set; }
}