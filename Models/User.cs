namespace perkmaker_backend.Models
{
    public class User
    {
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        protected User()
        {
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }
}
