using System.ComponentModel.DataAnnotations;

namespace GameShop.Models.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Ввведите имя пользователя!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ввведите пароль!")]
        public string Password { get; set; }
    }
}
