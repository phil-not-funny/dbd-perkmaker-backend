namespace perkmaker_backend.Models
{
    public class PerksEntry: Entry
    {
        protected PerksEntry() { }
        public PerksEntry(string header, Perk[] perks): base(header, EntryType.Perks)
        {
            Perks = perks;
        }
        public Perk[] Perks { get; set; }
    }
}
