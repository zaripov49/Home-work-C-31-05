using System.Net;
using Domain.ApiResponse;
using Domain.DTOS.PostDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PostService(DataContext context) : IPostService
{
    public async Task<Response<List<GetPostDTO>>> GetAllPostsAsync()
    {
        var posts = await context.Posts
            // .Include(p => p.Posts)
            .Select(p => new GetPostDTO()
            {
                Id = p.Id,
                UserId = p.UserId,
                Username = p.User.Username,
                Content = p.Content,
                CreatedAt = p.CreatedAt,
                CommentCount = p.Comments.Count()
            }).ToListAsync();
        return new Response<List<GetPostDTO>>(posts, "Successfuly");
    }

    public async Task<Response<GetPostDTO?>> GetPostByIdAsync(int id)
    {
        var result = await context.Posts.FindAsync(id);
        if (result == null)
        {
            return new Response<GetPostDTO?>("Post Not Found", HttpStatusCode.NotFound);
        }

        var post = new GetPostDTO
        {
            Id = result.Id,
            UserId = result.UserId,
            Username = result.User.Username,
            Content = result.Content,
            CreatedAt = result.CreatedAt,
            CommentCount = result.Comments.Count()
        };

        if (post == null)
        {
            return new Response<GetPostDTO?>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<GetPostDTO?>(post, "Successfuly");
    }

    public async Task<Response<string>> CreatePostAsync(CreatePostDTO createPostDTO)
    {
        var post = new Post
        {
            UserId = createPostDTO.UserId,
            Content = createPostDTO.Content,
            CreatedAt = createPostDTO.CreatedAt
        };

        await context.Posts.AddAsync(post);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Created Post Successfuly");
    }

    public async Task<Response<string>> UpdatePostAsync(int id, UpdatePostDTO updatePostDTO)
    {
        var PostToUpdate = await context.Posts.FindAsync(id);
        if (PostToUpdate == null)
        {
            return new Response<string>("Post Not Found", HttpStatusCode.NotFound);
        }

        PostToUpdate.UserId = updatePostDTO.UserId;
        PostToUpdate.Content = updatePostDTO.Content;
        PostToUpdate.CreatedAt = updatePostDTO.CreatedAt;

        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Updated Post Successfuly");
    }

    public async Task<Response<string>> DeletePostAsync(int id)
    {
        var post = await context.Posts.FindAsync(id);
        if (post == null)
        {
            return new Response<string>("Post not Found", HttpStatusCode.NotFound);
        }

        context.Posts.Remove(post);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Deleted Post Successfuly");
    }
}
