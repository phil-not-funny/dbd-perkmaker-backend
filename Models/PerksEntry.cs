namespace perkmaker_backend.Models
{
    public class PerksEntry: Entry
    {
        protected PerksEntry() { }
        public PerksEntry(string header, List<Perk> perks): base(header, EntryType.Perks)
        {
            Perks = perks;
        }
        public List<Perk> Perks { get; } = new();
    }
}
