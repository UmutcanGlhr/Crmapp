using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        IEnumerable<IdentityRole> Roles { get; }
        IEnumerable<AppUser> GetAllUsers();

        Task Update(AppUserDtoUpdate userDtoUpdate, string id);
        Task<AppUser>? GetOneUser(string? id);

        Task<IdentityResult> ResetPassword(ResetPasswordDto passwordDto, string Id);

        Task UserActive(string id,string baslangicTarihi , string bitisTarihi);

        Task userInActive(string id);
        Task OnShowCase(string id);
        Task closeShowCase(string id);
    }
}