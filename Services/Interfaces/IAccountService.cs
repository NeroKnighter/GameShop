using GameShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GameShop.Domain;
using GameShop.Domain.Models.ViewModels;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        BaseResponse<ClaimsIdentity> Register(RegisterViewModel model);
        BaseResponse<ClaimsIdentity> LogIn(LogInViewModel model);
        BaseResponse<ClaimsIdentity> ChangeThePassword(ChangeThePasswordViewModel model);
        BaseResponse<ClaimsIdentity> EditTheProfile(EditViewModel model);

    }
}
