namespace CafeMenuApp.Application.DTO.Category;
public class DetailCategoryDto : BaseDto
{
    public string Name { get; set; }
    public string? ParentCategoryName { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
