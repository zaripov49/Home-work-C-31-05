using Domain.ApiResponse;
using Domain.Entities;
using Domain.FIlters;

namespace Infrastructure.Interfaces;

public interface IUserRepository
{
    Task<PagedResponse<List<User>>> GetAllAsync(UserFilter filter);
    Task<User?> GetAsync(int id);
    Task<int> CreateAsync(User user);
    Task<int> UpdateAsync(User user);
    Task<int> DeleteAsync(User user);
}
