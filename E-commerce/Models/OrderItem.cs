using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public double price { get; set; }

        public int movieId { get; set; }
        [ForeignKey("movieId")]
        public  Movie Movie { get; set; }

        public int orderId { get; set; }
        [ForeignKey("orderId")]
        public Order order { get; set; }
    }
}
