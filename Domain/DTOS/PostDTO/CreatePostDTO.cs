namespace Domain.DTOS.PostDTO;

public class CreatePostDTO
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int CommentCount { get; set; }
}
