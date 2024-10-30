namespace GameShop.Models
{
    public class Game
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Photo { get; set; }
        public int GenreId { get; set; }
        public int Price { get; set; }

    }
}
