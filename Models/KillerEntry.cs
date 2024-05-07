namespace perkmaker_backend.Models
{
    public class KillerEntry: Entry
    {
        public KillerEntry(string header, Killer killer): base(header, EntryType.Killer)
        {
            Killer = killer;
        }
        protected KillerEntry() { }
        public Killer Killer { get; set; }
    }
}
