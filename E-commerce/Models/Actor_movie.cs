namespace E_commerce.Models
{
    public class Actor_movie
    {
        public int movieId { get; set; }
        public Movie movie { get; set; }
        public int actorId { get; set; }
        public Actor actor { get; set; }
    }
}
