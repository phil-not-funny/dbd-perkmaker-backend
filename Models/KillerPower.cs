namespace perkmaker_backend.Models
{
    public class KillerPower
    {
        public KillerPower(string name, string description, string image)
        {
            Name = name;
            Description = description;
            Image = image;
        }
        protected KillerPower() { }
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
