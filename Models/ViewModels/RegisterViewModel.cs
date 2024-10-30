using System.ComponentModel.DataAnnotations;

namespace GameShop.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ввведите имя пользователя!")]
        [MinLength(3, ErrorMessage = "Минимальная длина имени - 3!")]
        [MaxLength(20, ErrorMessage = "Максимальная длина имени - 20!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ввведите пароль!")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6!")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля - 20!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string PasswordConfirm { get; set; }
    }
}
