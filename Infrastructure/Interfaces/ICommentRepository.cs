using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICommentRepository
{
    Task<Response<List<Comment>>> GetAllAsync();
    Task<Comment> GetAsync(int id);
    Task<int> CreateAsync(Comment comment);
    Task<int> UpdateAsync(Comment comment);
    Task<int> DeleteAsync(Comment comment);
}
