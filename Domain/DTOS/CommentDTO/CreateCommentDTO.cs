namespace Domain.DTOS.CommentDTO;

public class CreateCommentDTO
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public int PostId { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; }
}
