using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Producer:person
    {
        //Relationships
        public List<Movie> Movies { get; set; }
  
    }
}
