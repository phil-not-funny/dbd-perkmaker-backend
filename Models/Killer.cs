namespace perkmaker_backend.Models
{
    public class Killer
    {
        public Killer(string name, string description, string image, List<Perk> perks, KillerPower killerPower)
        {
            Name = name;
            Description = description;
            Image = image;
            Perks = perks;
            KillerPower = killerPower;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<Perk> Perks { get; } = new();
        public KillerPower KillerPower { get; set; }
    }
}
