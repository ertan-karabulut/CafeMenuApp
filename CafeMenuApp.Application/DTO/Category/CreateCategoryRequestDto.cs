namespace CafeMenuApp.Application.DTO.Category;

public class CreateCategoryRequestDto
{
    public string Name { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
