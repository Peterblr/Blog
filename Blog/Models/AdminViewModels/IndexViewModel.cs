using Blog.Data.Models;

namespace Blog.Models.AdminViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts{ get; set; }
    }
}
