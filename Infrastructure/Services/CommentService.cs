using System.Net;
using Domain.ApiResponse;
using Domain.DTOS.CommentDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CommentService(DataContext context) : ICommentService
{
    public async Task<Response<List<GetCommentDTO>>> GetAllCommentsAsync()
    {
        var comments = await context.Comments
            // .Include(us => us.Posts)
            .Select(us => new GetCommentDTO()
            {
                Id = us.Id,
                UserId = us.UserId,
                Username = us.User.Username,
                PostId = us.PostId,
                Text = us.Text,
                CreatedAt = us.CreatedAt
            }).ToListAsync();
        return new Response<List<GetCommentDTO>>(comments, "Successfuly");
    }

    public async Task<Response<GetCommentDTO?>> GetCommentByIdAsync(int id)
    {
        var result = await context.Comments.FindAsync(id);
        if (result == null)
        {
            return new Response<GetCommentDTO?>("Comment Not Found", HttpStatusCode.NotFound);
        }

        var comment = new GetCommentDTO
        {
            Id = result.Id,
            UserId = result.UserId,
            Username = result.User.Username,
            PostId = result.PostId,
            Text = result.Text,
            CreatedAt = result.CreatedAt
        };

        if (comment == null)
        {
            return new Response<GetCommentDTO?>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<GetCommentDTO?>(comment, "Successfuly");
    }

    public async Task<Response<string>> CreateCommentAsync(CreateCommentDTO createCommentDTO)
    {
        var comment = new Comment
        {
            UserId = createCommentDTO.UserId,
            PostId = createCommentDTO.PostId,
            Text = createCommentDTO.Text,
            CreatedAt = createCommentDTO.CreatedAt
            // Posts.Count() = createCommentDTO.PostCount
        };

        await context.Comments.AddAsync(comment);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Created Comment Successfuly");
    }

    public async Task<Response<string>> UpdateCommentAsync(int id, UpdateCommentDTO updateCommentDTO)
    {
        var CommentToUpdate = await context.Comments.FindAsync(id);
        if (CommentToUpdate == null)
        {
            return new Response<string>("Comment Not Found", HttpStatusCode.NotFound);
        }

        CommentToUpdate.UserId = updateCommentDTO.UserId;
        CommentToUpdate.UserId = updateCommentDTO.UserId;
        CommentToUpdate.UserId = updateCommentDTO.UserId;
        CommentToUpdate.Text = updateCommentDTO.Text;

        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Updated Comment Successfuly");
    }

    public async Task<Response<string>> DeleteCommentAsync(int id)
    {
        var comment = await context.Comments.FindAsync(id);
        if (comment == null)
        {
            return new Response<string>("Comment not Found", HttpStatusCode.NotFound);
        }

        context.Comments.Remove(comment);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Deleted Comment Successfuly");
    }
}
