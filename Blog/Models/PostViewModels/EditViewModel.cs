using Blog.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.PostViewModels
{
    public class EditViewModel
    {
        [Display(Name = "Header Image")]
        public IFormFile HeaderImage { get; set; }

        public Post Post { get; set; }
    }
}
