namespace CafeMenuApp.Application.DTO.User;

public class DetailUserDto : BaseDto
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string UserName { get; set; }
    public string? Password { get; set; }
}
