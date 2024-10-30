using System.ComponentModel.DataAnnotations;

namespace GameShop.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пароль")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Минимальная длина пароля - 6")]
        [MaxLength(20, ErrorMessage = "Максимальная длина пароля - 6")]
        public string Password { get; set; }
        public string Role { get; set; }   

    }
}
