using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repasitories;

public class CommentRepository(DataContext context) : ICommentRepository
{
    public async Task<int> CreateAsync(Comment comment)
    {
        await context.Comments.AddAsync(comment);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Comment comment)
    {
        context.Comments.Remove(comment);
        return await context.SaveChangesAsync();
    }

    public async Task<Response<List<Comment>>> GetAllAsync()
    {
        var comments = await context.Comments.ToListAsync();
        return new Response<List<Comment>>(comments);
    }

    public async Task<Comment> GetAsync(int id)
    {
        var comment = await context.Comments.FindAsync(id);
        return comment!;
    }

    public async Task<int> UpdateAsync(Comment comment)
    {
        context.Comments.Update(comment);
        return await context.SaveChangesAsync();
    }

}
