using Blog.BusinessManager.Interfaces;
using Blog.Data.Models;
using Blog.Models.HomeViewModels;
using Blog.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Blog.BusinessManager
{
    public class HomeBusinessManager : IHomeBusinessManager
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public HomeBusinessManager(
            IPostService postService,
            IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        public ActionResult<AuthorViewModel> GetAuthorViewModel(string authorId, string searchString, int? page)
        {
            if (authorId is null)
                return new BadRequestResult();

            var applicationUser = _userService.GetUser(authorId);

            if (applicationUser is null)
                return new NotFoundResult();

            int pageSize = 3;
            int pageNumber = page ?? 1;

            var posts = _postService.GetAllPosts(searchString ?? string.Empty)
                .Where(post => post.Published && post.Creator == applicationUser && post.Approved);

            return new AuthorViewModel
            {
                Author = applicationUser,
                Posts = new StaticPagedList<Post>(posts.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, posts.Count()),
                SearchString = searchString,
                PageNumber = pageNumber
            };
        }
    }
}
