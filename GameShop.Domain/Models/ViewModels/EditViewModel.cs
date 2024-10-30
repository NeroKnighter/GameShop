using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Models.ViewModels
{
    public class EditViewModel
    {
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
        [Required(ErrorMessage = "Поле номер телефона обязательно для заполнения.")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Введите корректный формат номера телефона")]
        public string PhoneNumber { get; set; }
        public string? CreditCard { get; set; }
    }
}
