using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IPostRepository
{
    Task<Response<List<Post>>> GetAllAsync();
    Task<Post> GetAsync(int id);
    Task<int> CreateAsync(Post post);
    Task<int> UpdateAsync(Post post);
    Task<int> DeleteAsync(Post post);
}
