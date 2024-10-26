namespace CafeMenuApp.Application.DTO.Product;
public class CreateProductRequestDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }
    public Guid CategoryId { get; set; }
}
