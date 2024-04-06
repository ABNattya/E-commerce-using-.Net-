using E_commerce.Data.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class cinema : IEntityBase
    {
   
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("description")]
        public string discription { get; set; }

        [DisplayName("Cinema Logo")]
        public string logoUrl { get; set; }
        //Relationships
        public  List<Movie> Movies { get; set; }

        
    }

}

