using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

        public async Task closeShowCase(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is not null)
            {
                user.ShowCase = false;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                }
                else
                {
                    throw new Exception("System have a problem");
                }
            }
            else
            {
                throw new Exception("System have a problem");
            }
            return;
        }

        public IEnumerable<AppUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<AppUser>? GetOneUser(string? id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
                throw new Exception(" user Not Found");
            return user;
        }

        public async Task OnShowCase(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is not null)
            {
                user.ShowCase = true;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                }
                else
                {
                    throw new Exception("System have a problem");

                }
            }
            else
            {
                throw new Exception("System have a problem");
            }
            return;
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto passwordDto, string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user is not null)
            {
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, passwordDto.Password);
                return result;
            }
            else
            {
                throw new Exception("User could not be found");
            }
        }

        public async Task Update(AppUserDtoUpdate userDtoUpdate, string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is not null)
            {
                user.AD = userDtoUpdate.AD;
                user.SOYAD = userDtoUpdate.SOYAD;
                user.FirmaAdi = userDtoUpdate.FirmaAdi;
                user.FirmaLogo = userDtoUpdate.FirmaLogo;
                user.Şehir = userDtoUpdate.Şehir;
                user.İlçe = userDtoUpdate.İlçe;
                user.TamAdres = userDtoUpdate.TamAdres;
                user.categoryID = userDtoUpdate.categoryID;
                user.Biyografi = userDtoUpdate.Biyografi;
                user.uzmanlikAlani = userDtoUpdate.uzmanlikAlani;
                user.baslangic = userDtoUpdate.baslangic;
                user.bitis = userDtoUpdate.bitis;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                }
                else
                {
                    throw new Exception("System have a problem");
                }
            }
            else
            {
                throw new Exception("System have a problem");
            }
            return;
        }

        public async Task UserActive(string id,string baslangicTarihi , string bitisTarihi)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is not null)
            {
                user.aktive = true;
                user.baslangic=baslangicTarihi;
                user.bitis=bitisTarihi;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                }
                else
                {
                    throw new Exception("System have a problem");
                }
            }
            else
            {
                throw new Exception("System have a problem");
            }
            return;
        }

        public async Task userInActive(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is not null)
            {
                user.aktive = false;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {

                }
                else
                {
                    throw new Exception("System have a problem");
                }
            }
            else
            {
                throw new Exception("System have a problem");
            }
            return;
        }


    }
}