﻿using Blog.BusinessManager.Interfaces;
using Blog.Models.PostViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostBusinessManager _postBusinessManager;

        public PostController(IPostBusinessManager postBusinessManager)
        {
            _postBusinessManager = postBusinessManager;
        }

        [Route("Post/{id}"), AllowAnonymous]
        public async Task<IActionResult>Index(int? id)
        {
            var actionResult = await _postBusinessManager.GetPostViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }

        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel createViewModel)
        {
            await _postBusinessManager.CreatePost(createViewModel, User);

            return RedirectToAction("Index", "Admin", new { area = "" });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var actionResult = await _postBusinessManager.GetEditViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel editViewModel)
        {
            var actionResult = await _postBusinessManager.UpdatePost(editViewModel, User);

            if (actionResult.Result is null)
            {
                return RedirectToAction("Index", "Admin", new { area = "" });
            }

            return actionResult.Result;
        }

    }
}
