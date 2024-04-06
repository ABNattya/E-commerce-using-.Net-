using E_commerce.Data.Base;
using E_commerce.Data.enums;
using E_commerce.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace E_commerce.Models
{
    public class MovieVM
    {

        public int id { get; set; }
        [Display(Description ="Movie Description")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Display(Description = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Description = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is required")]
        public string picUrl { get; set; }

        [Display(Description = " Movie Price")]
        [Required(ErrorMessage = "Price is required")]
        public double price { get; set; }

        [Display(Description = " Start date ")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime startTime { get; set; }

        [Display(Description = " End date ")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime endTime { get; set; }

        [Display(Description = "  select movie Category ")]
        [Required(ErrorMessage = "movie Category is required")]
        public MovieCategory movieCategory { get; set; }

        [Display(Description = "  select Actor(s) ")]
        [Required(ErrorMessage = "movie Actor(s) is required")]
       
        public List<int> ActorsId { get; set; }

        //cinema
        [Display(Description = "  select cinema(s) ")]
        [Required(ErrorMessage = "movie cinema(s) is required")]

  
        public int cinemaId {  get; set; }

        //producer
        [Display(Description = "  select producer(s) ")]
        [Required(ErrorMessage = "movie producer(s) is required")]

     
        public int producerId { get; set; }
   

    }


}
