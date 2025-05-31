using Domain.ApiResponse;
using Domain.DTOS.PostDTO;

namespace Infrastructure.Interfaces;

public interface IPostService
{
    Task<Response<List<GetPostDTO>>> GetAllPostsAsync();
    Task<Response<GetPostDTO?>> GetPostByIdAsync(int id);
    Task<Response<string>> CreatePostAsync(CreatePostDTO createPostDTO);
    Task<Response<string>> UpdatePostAsync(int id,  UpdatePostDTO updatePostDTO);
    Task<Response<string>> DeletePostAsync(int id);
}
