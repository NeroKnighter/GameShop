using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Domain.Models.ViewModels
{
    public class GameEditViewModel
    {

        [Required(ErrorMessage = "Введите название игры!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите описание игры!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Выберите фото игры!")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Выберите жанр игры!")]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Введите цену игры!")]
        public int Price { get; set; }
    }
}
