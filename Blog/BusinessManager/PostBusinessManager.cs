using Blog.BusinessManager.Interfaces;
using Blog.Data.Models;
using Blog.Models.PostViewModels;
using Blog.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Blog.BusinessManager
{
    public class PostBusinessManager : IPostBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPostService _postService;

        public PostBusinessManager(UserManager<ApplicationUser> userManager,
                                    IPostService postService)
        {
            _userManager = userManager;
            _postService = postService;
        }

        public async Task<Post> CreatePost(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal)
        {
            Post post = createViewModel.Post;
           
            post.Creator = await _userManager.GetUserAsync(claimsPrincipal);
            post.CreatedOn = DateTime.Now;
            post.UpdatedOn = DateTime.Now;

            return await _postService.Add(post);
        }
    }
}
