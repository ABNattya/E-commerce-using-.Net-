using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Movie movie { get; set; }

        public int quantity { get; set; }


        public string ShoppingCartId { get; set; }

    }
}
