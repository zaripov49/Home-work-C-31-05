using Domain.ApiResponse;
using Domain.Entities;
using Domain.FIlters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repasitories;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<PagedResponse<List<User>>> GetAllAsync(UserFilter filter)
    {
        var query = context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Username))
        {
            query = query.Where(c => c.Username!.ToLower().Trim().Contains(filter.Username.ToLower().Trim()));
        }


        var pagination = new Pagination<User>(query);
        return await pagination.GetPagedResponseAsync(filter.PageNumber, filter.PageSize);
    }

    public async Task<User?> GetAsync(int id)
    {
        var course = await context.Users.FindAsync(id);
        return course;
    }

    public async Task<int> CreateAsync(User course)
    {
        await context.Users.AddAsync(course);
        return await context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(User course)
    {
        context.Users.Update(course);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(User course)
    {
        context.Users.Remove(course);
        return await context.SaveChangesAsync();
    }
}
