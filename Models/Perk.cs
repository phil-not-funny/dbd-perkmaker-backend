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
        protected Perk() { }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
