using Repositories.Implementations;
using Services.Interfaces;
using System.Security.Claims;
using GameShop.Domain.Models;
using GameShop.Domain;
using GameShop.Domain.Models.ViewModels;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Services.Implementations
{
    public class AccountService : IAccountService
    {
        private IBaseRepository<User> _userRepository;
        public AccountService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public BaseResponse<ClaimsIdentity> Register(RegisterViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (user != null)
            {
                return new BaseResponse<ClaimsIdentity>
                {
                    Description = "Такой пользователь уже есть"
                };
            }
            else
            {
                user = new User
                {
                    ProfileName = model.ProfileName,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic,
                    PhoneNumber = model.PhoneNumber,
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    Role = "User"
                };
                _userRepository.Create(user);
                var result = Authenticate(user);
                return new BaseResponse<ClaimsIdentity>
                {
                    Data = result,
                    Description = "Пользователь добавлен",
                    StatusCode = "OK"
                };
            }
        }
        public BaseResponse<ClaimsIdentity> LogIn(LogInViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>
                {
                    Description = "Такого пользователя не существует"
                };
            }
            else
            {
                if (user.Password == model.Password)
                {
                    var result = Authenticate(user);
                    return new BaseResponse<ClaimsIdentity>
                    {
                        Data = result,
                        Description = "Пользователь авторизован",
                        StatusCode = "OK"
                    };
                }
                else
                {
                    return new BaseResponse<ClaimsIdentity>
                    {
                        Description = "Пароль неверный",
                        StatusCode = "Error"
                    };
                }
            }
        }

        public BaseResponse<ClaimsIdentity> ChangeThePassword(ChangeThePasswordViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            user.Password = model.NewPassword;
            _userRepository.Update(user);

            return new BaseResponse<ClaimsIdentity>
            {
                Description = "Пароль обновлен",
                StatusCode = "OK",
            };
        }
        public BaseResponse<ClaimsIdentity> EditTheProfile(EditViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);

            user.Name = model.Name;
            user.ProfileName = model.ProfileName;
            user.Surname = model.Surname;
            user.Patronymic = model.Patronymic;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.CreditCard = model.CreditCard;
            _userRepository.Update(user);

            return new BaseResponse<ClaimsIdentity>
            {
                Description = "Профиль обновлен",
                StatusCode = "OK"
            };
        }

        public ClaimsIdentity Authenticate(User user)
        {
            var Claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };
            return new ClaimsIdentity(Claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
