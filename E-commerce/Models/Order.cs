using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserId {  get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser user { get; set; }
        public List<OrderItem> Items { get; set;}
    }
}
