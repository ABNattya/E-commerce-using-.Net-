using E_commerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
    public class Actor : person ,IEntityBase
    {
        //Relationships
        public  List<Actor_movie> actor_Movies { get; set; }
    }
}
