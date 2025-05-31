using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Post
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [Required(ErrorMessage = "Пожалуйста введите свой content!")]
    [MaxLength(500, ErrorMessage = "content не может быть больше 500 символов")]
    [MinLength(3, ErrorMessage = "content не может быть меньше 3 символов")]
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }

    // navigation
    public User? User { get; set; }
    public List<Comment>? Comments { get; set; }
}
