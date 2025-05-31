using System.Net;
using Domain.ApiResponse;
using Domain.DTOS;
using Domain.DTOS.UserDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserService(DataContext context) : IUserService
{
    public async Task<Response<List<GetUserDTO>>> GetAllUsersAsync()
    {
        var users = await context.Users
            // .Include(us => us.Posts)
            .Select(us => new GetUserDTO()
            {
                Id = us.Id,
                Username = us.Username,
                Email = us.Email,
                PostCount = us.Posts.Count()
            }).ToListAsync();
        return new Response<List<GetUserDTO>>(users, "Successfuly");
    }

    public async Task<Response<GetUserDTO?>> GetUserByIdAsync(int id)
    {
        var result = await context.Users.FindAsync(id);
        if (result == null)
        {
            return new Response<GetUserDTO?>("User Not Found", HttpStatusCode.NotFound);
        }

        var user = new GetUserDTO
        {
            Id = result.Id,
            Username = result.Email,
            PostCount = result.Posts.Count()
        };

        if (user == null)
        {
            return new Response<GetUserDTO?>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<GetUserDTO?>(user, "Successfuly");
    }

    public async Task<Response<string>> CreateUserAsync(CreateUserDTO createUserDTO)
    {
        var user = new User
        {
            Username = createUserDTO.Username,
            Email = createUserDTO.Email
            // Posts.Count() = createUserDTO.PostCount
        };

        await context.Users.AddAsync(user);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Created User Successfuly");
    }

    public async Task<Response<string>> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO)
    {
        var userToUpdate = await context.Users.FindAsync(id);
        if (userToUpdate == null)
        {
            return new Response<string>("User Not Found", HttpStatusCode.NotFound);
        }

        userToUpdate.Username = updateUserDTO.Username;
        userToUpdate.Email = updateUserDTO.Email;

        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Updated User Successfuly");
    }

    public async Task<Response<string>> DeleteUserAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return new Response<string>("User not Found", HttpStatusCode.NotFound);
        }

        context.Users.Remove(user);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Deleted User Successfuly");
    }
}
