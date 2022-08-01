using Blog.Data.Models;
using Blog.Models.HomeViewModels;
using Blog.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.BusinessManager.Interfaces
{
    public interface IPostBusinessManager
    {
        Task<Post> CreatePost(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> UpdatePost(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal);

        Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);

        IndexHomeViewModel GetIndexHomeViewModel(string searchString, int? page);

        Task<ActionResult<PostViewModel>> GetPostViewModel(int? id, ClaimsPrincipal claimsPrincipal);

        Task<ActionResult<Comment>> CreateComment(PostViewModel postViewModel, ClaimsPrincipal claimsPrincipal);
    }
}
