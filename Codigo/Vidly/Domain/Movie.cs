namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}