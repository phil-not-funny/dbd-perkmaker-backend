namespace perkmaker_backend.Models
{
    public class Killer
    {
        public Killer(string name, string description, string image, Perk[] perks, KillerPower killerPower)
        {
            Name = name;
            Description = description;
            Image = image;
            Perks = perks;
            KillerPower = killerPower;
        }
        protected Killer() { }
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Perk[] Perks { get; set; }
        public KillerPower KillerPower { get; set; }
    }
}
