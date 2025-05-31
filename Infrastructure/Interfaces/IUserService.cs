using Domain.ApiResponse;
using Domain.DTOS;
using Domain.DTOS.UserDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IUserService
{
    Task<Response<List<GetUserDTO>>> GetAllUsersAsync();
    Task<Response<GetUserDTO?>> GetUserByIdAsync(int id);
    Task<Response<string>> CreateUserAsync(CreateUserDTO createUserDTO);
    Task<Response<string>> UpdateUserAsync(int id,  UpdateUserDTO updateUserDTO);
    Task<Response<string>> DeleteUserAsync(int id);
}
