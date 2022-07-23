using Blog.Models.AdminViewModels;
using System.Security.Claims;

namespace Blog.BusinessManager.Interfaces
{
    public interface IAdminBusinessManager
    {
        Task<IndexViewModel> GetAdminDashboardAsync(ClaimsPrincipal claimsPrincipal);
    }
}
