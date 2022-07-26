using Blog.Data;
using Blog.Data.Models;
using Blog.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Post GetPost(int postId)
        {
            return _applicationDbContext.Posts
                .Include(post => post.Creator)
                .Include(post => post.Comments)
                    .ThenInclude(comment => comment.Author)
                .Include(post => post.Comments)
                    .ThenInclude(comment => comment.Comments)
                .FirstOrDefault(post => post.Id == postId);
        }

        public IEnumerable<Post> GetAllPosts(string searchString)
        {
            return _applicationDbContext.Posts
                .OrderByDescending(post => post.UpdatedOn)
                .Include(post => post.Creator)
                .Include(post => post.Comments)
                .Where(post => post.Title.Contains(searchString) || post.Content.Contains(searchString));
        }

        public IEnumerable<Post> GetAllPosts(ApplicationUser applicationUser)
        {
            return _applicationDbContext.Posts
                .OrderByDescending(post => post.UpdatedOn)
                .Include(post => post.Creator)
                .Include(post => post.Approver)
                .Include(post => post.Comments)
                .Where(post => post.Creator == applicationUser);
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            _applicationDbContext.Add(post);
            await _applicationDbContext.SaveChangesAsync();

            return post;
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            _applicationDbContext.Update(post);
            await _applicationDbContext.SaveChangesAsync();

            return post;
        }

        public Comment GetComment(int commentId)
        {
            return _applicationDbContext.Comments
                .Include(comment => comment.Author)
                .Include(comment => comment.Post)
                .Include(comment => comment.CreatedOn)
                .FirstOrDefault(comment => comment.Id == commentId);
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            _applicationDbContext.Add(comment);
            await _applicationDbContext.SaveChangesAsync();

            return comment;
        }
    }
}
