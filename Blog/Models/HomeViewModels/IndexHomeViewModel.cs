using Blog.Data.Models;
using PagedList.Core;

namespace Blog.Models.HomeViewModels
{
    public class IndexHomeViewModel
    {
        public IPagedList<Post> Posts { get; set; }

        public string SearchString { get; set; }

        public int PageNumber { get; set; }
    }
}
