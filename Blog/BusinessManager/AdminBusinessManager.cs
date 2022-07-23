using Blog.BusinessManager.Interfaces;
using Blog.Data.Models;
using Blog.Models.AdminViewModels;
using Blog.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Blog.BusinessManager
{
    public class AdminBusinessManager : IAdminBusinessManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPostService _postService;

        public AdminBusinessManager(UserManager<ApplicationUser> userManager, 
                                    IPostService postService)
        {
            _userManager = userManager;
            _postService = postService;
        }

        public async Task<IndexViewModel> GetAdminDashboardAsync(ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await _userManager.GetUserAsync(claimsPrincipal);

            return new IndexViewModel
            {
                Posts = _postService.GetAllPosts(applicationUser),
            };
        }
    }
}
