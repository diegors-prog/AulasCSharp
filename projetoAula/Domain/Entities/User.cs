namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public string Bio { get; set; }

        public IList<Role> Roles { get; set; }
    }
}