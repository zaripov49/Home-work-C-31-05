namespace Domain.DTOS;

public class CreateUserDTO
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public int PostCount { get; set; }
}
