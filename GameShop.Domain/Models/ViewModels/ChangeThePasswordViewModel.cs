using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameShop.Domain.Models.ViewModels
{
    public class ChangeThePasswordViewModel
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Пароль должен содержать хотя бы одну букву и одну цифру.")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля - 20")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль!")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают!")]
        public string PasswordConfirm { get; set; }
    }
}
