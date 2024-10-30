using System.ComponentModel.DataAnnotations;

namespace GameShop.Domain.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [MinLength(6, ErrorMessage = "Минимальная длина логина - 6")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string ProfileName { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Введите отчество")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Введите почтовый адрес")]
        [EmailAddress(ErrorMessage = "Введите корректный почтовый адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введит номер телефона.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Введите корректный формат номера телефона")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Пароль должен содержать хотя бы одну букву и одну цифру.")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля - 20")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
