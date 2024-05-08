namespace perkmaker_backend.Models
{
    public class PerksEntry: Entry
    {
        protected PerksEntry() { }
        public PerksEntry(string header, List<Perk> perks, User user) : base(header, EntryType.Perks, user)
        {
            Perks = perks;
        }
        public List<Perk> Perks { get; } = new();
    }
}
