namespace Domain.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

        public IList<User> Users { get; set; }
    }
}