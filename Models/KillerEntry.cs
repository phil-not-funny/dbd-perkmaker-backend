namespace perkmaker_backend.Models
{
    public class KillerEntry: Entry
    {
        public KillerEntry(string header, Killer killer, User user) : base(header, EntryType.Killer, user)
        {
            Killer = killer;
        }
        protected KillerEntry() { }
        public Killer Killer { get; set; }
    }
}
