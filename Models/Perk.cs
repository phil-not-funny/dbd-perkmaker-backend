namespace perkmaker_backend.Models
{
    public class Perk
    {
        public Perk(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
