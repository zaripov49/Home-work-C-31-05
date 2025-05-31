using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Пожалуйста введите свой username!")]
    [MaxLength(50, ErrorMessage = "username не может быть больше 50 символов")]
    [MinLength(3, ErrorMessage = "username не может быть меньше 3 символов")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Пожалуйста введите свой email!")]
    [MaxLength(100, ErrorMessage = "email не может быть больше 100 символов")]
    [MinLength(3, ErrorMessage = "email не может быть меньше 3 символов")]
    public string? Email { get; set; }
    [MaxLength(200, ErrorMessage = "bio не может быть больше 200 символов")]
    [MinLength(3, ErrorMessage = "bio не может быть меньше 3 символов")]
    public string? Bio { get; set; }

    // navigation
    public List<Post>? Posts { get; set; }
    public List<Comment>? Comments { get; set; }
}
