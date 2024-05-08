using Microsoft.EntityFrameworkCore;

namespace perkmaker_backend.Models
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
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
        public List<Entry> Entries { get; set; } = new();

    }
}
