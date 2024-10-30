using System.ComponentModel.DataAnnotations;

namespace GameShop.Models.ViewModels
{
    public class ChangeThePasswordViewModel
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Ввведите старый пароль!")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Введите новый пароль!")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль!")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmPassword { get; set; }
    }
}
