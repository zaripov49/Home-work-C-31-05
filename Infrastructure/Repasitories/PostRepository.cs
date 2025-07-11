using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repasitories;

public class PostRepository(DataContext context) : IPostRepository
{
    public async Task<int> CreateAsync(Post post)
    {
        await context.Posts.AddAsync(post);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Post post)
    {
        context.Posts.Remove(post);
        return await context.SaveChangesAsync();
    }

    public async Task<Response<List<Post>>> GetAllAsync()
    {
        var posts = await context.Posts.ToListAsync();
    return new Response<List<Post>>(posts);
    }

    public async Task<Post> GetAsync(int id)
    {
        var post = await context.Posts.FindAsync(id);
        return post!;
    }

    public async Task<int> UpdateAsync(Post post)
    {
        context.Posts.Update(post);
        return await context.SaveChangesAsync();
    }

}
