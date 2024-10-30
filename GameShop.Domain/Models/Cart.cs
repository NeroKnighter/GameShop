namespace GameShop.Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public List<Game> CartGames = new List<Game>(); 
    }
}
