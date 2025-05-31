using Domain.ApiResponse;
using Domain.DTOS.CommentDTO;

namespace Infrastructure.Interfaces;

public interface ICommentService
{
    Task<Response<List<GetCommentDTO>>> GetAllCommentsAsync();
    Task<Response<GetCommentDTO?>> GetCommentByIdAsync(int id);
    Task<Response<string>> CreateCommentAsync(CreateCommentDTO createCommentDTO);
    Task<Response<string>> UpdateCommentAsync(int id,  UpdateCommentDTO updateCommentDTO);
    Task<Response<string>> DeleteCommentAsync(int id);
}
