using Blog.Models.AdminViewModels;
using System.Security.Claims;

namespace Blog.BusinessManager.Interfaces
{
    public interface IAdminBusinessManager
    {
        Task<IndexViewModel> GetAdminDashboardAsync(ClaimsPrincipal claimsPrincipal);

        Task<AboutViewModel> GetAboutViewModel(ClaimsPrincipal claimsPrincipal);

        Task UpdateAboutViewModel(AboutViewModel aboutViewModel, ClaimsPrincipal claimsPrincipal);
    }
}
