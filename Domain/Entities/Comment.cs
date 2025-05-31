using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Comment
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    [ForeignKey("Post")]
    public int PostId { get; set; }
    [Required(ErrorMessage = "Пожалуйста введите свой text!")]
    [MaxLength(300, ErrorMessage = "text не может быть больше 300 символов")]
    [MinLength(3, ErrorMessage = "text не может быть меньше 3 символов")]
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; }

    // navigation
    public User? User { get; set; }
    public Post? Post { get; set; }
}
