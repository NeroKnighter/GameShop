using System.ComponentModel.DataAnnotations;

namespace GameShop.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите логин")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string ProfileName { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Введите отчество")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Введите E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите почту правильного формата")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Введите номер правильного формата")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Пароль")]
        [DataType(DataType.Password, ErrorMessage = "Введите пароль правильного формата")]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля - 20")]
        public string Password { get; set; }
        public string Role { get; set; }   
        public string? CreditCard { get; set; }

    }
}
