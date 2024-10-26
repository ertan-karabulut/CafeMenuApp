using CafeMenuApp.Application.DTO.Property;

namespace CafeMenuApp.Application.DTO.Product;
public class DetailProductDto : BaseDto
{

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }
    public string? CategoryName { get; set; }
    public Guid CategoryId { get; set; }
    public List<DetailPropertyDto> Properties { get; set; }
}
