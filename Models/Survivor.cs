namespace perkmaker_backend.Models
{
    public class Survivor
    {
        public Survivor(string name, string description, string image, List<Perk> perks)
        {
            Name = name;
            Description = description;
            Image = image;
            Perks = perks;
        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Perk> Perks { get; } = new();
    }
}
