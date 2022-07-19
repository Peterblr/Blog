using Blog.Data.Models;
using Blog.Models.PostViewModels;
using System.Security.Claims;

namespace Blog.BusinessManager.Interfaces
{
    public interface IPostBusinessManager
    {
        Task<Post> CreatePost(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal);
    }
}
