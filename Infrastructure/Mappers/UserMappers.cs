using Domain.DTOS;
using Domain.DTOS.UserDTO;
using Domain.Entities;

namespace Infrastructure.Mappers;

public static class UserMappers
{
    public static User ToEntity(CreateUserDTO userDTO)
    {
        return new User
        {
            Username = userDTO.Username,
            Email = userDTO.Email,
            Bio = userDTO.Bio,
        };
    }

    public static void ToEntity(this User course, UpdateUserDTO userDTO)
    {
        course.Username = userDTO.Username;
        course.Email = userDTO.Email;
        course.Bio = userDTO.Bio;
    }
}
