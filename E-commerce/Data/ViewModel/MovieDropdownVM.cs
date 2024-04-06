using E_commerce.Models;

namespace E_commerce.Data.ViewModel
{
    public class MovieDropdownVM
    {
        public MovieDropdownVM()
        {
            producers = new List<Producer>();
            actors = new List<Actor>();
            cinemas = new List<cinema>();

        }
        public List<Producer> producers { get; set; }
        public List<Actor> actors { get; set; }
        public List<cinema> cinemas { get; set; }

    }
}
