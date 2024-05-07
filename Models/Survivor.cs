namespace perkmaker_backend.Models
{
    public class Survivor
    {
        public Survivor(string name, string description, string image, Perk[] perks)
        {
            Name = name;
            Description = description;
            Image = image;
            Perks = perks;
        }
        protected Survivor() { }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Perk[] Perks { get; set; }
    }
}
