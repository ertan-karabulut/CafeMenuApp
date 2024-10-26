namespace CafeMenuApp.Application.DTO.Category;
public class ListCategoryResponseDto : BaseDto
{
    public string Name { get; set; }
    public string? ParentCategoryName { get; set; }
}
