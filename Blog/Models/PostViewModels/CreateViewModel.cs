using Blog.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.PostViewModels
{
    public class CreateViewModel
    {
        [Required, Display(Name = "Header Image")]
        public IFormFile HeaderImage { get; set; }

        public Post Post { get; set; }
    }
}
