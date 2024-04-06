using E_commerce.Data.Base;
using E_commerce.Data.enums;
using E_commerce.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace E_commerce.Models
{
    public class Movie:IEntityBase
    {
      
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string picUrl { get; set; }
        public double price { get; set; }   
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public MovieCategory movieCategory { get; set; }

        //Relationships
        public List<Actor_movie> actor_Movies { get; set; }

        //cinema
        public int cinemaId {  get; set; }
        [ForeignKey("cinemaId")]
        public cinema cinema { get; set; }

        //producer
        public int producerId { get; set; }
        [ForeignKey("producerId")]
        public Producer producer { get; set; }

    }


}
