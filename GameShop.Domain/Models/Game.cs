using System.ComponentModel.DataAnnotations;

namespace GameShop.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название игры!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание игры!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Выберите фото игры!")]
        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Выберите жанр игры!")]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Введите цену игры!")]
        public int Price { get; set; }

    }
}
