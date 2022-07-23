using Blog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Interfaces
{
    public interface IPostService
    {
        Post GetPost(int postId);

        IEnumerable<Post> GetAllPosts(ApplicationUser applicationUser);

        Task<Post> AddPostAsync(Post post);

        Task<Post> UpdatePostAsync(Post post);
    }
}
