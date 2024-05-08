namespace perkmaker_backend.Models
{
    public class Entry
    {
        public Entry(string header, EntryType type, User user)
        {
            Header = header;
            Type = type;
            User = user;
        }
        protected Entry() { }

        public enum EntryType
        {
            Perks, Survivor, Killer, AddOns
        }
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public EntryType Type { get; set; }
        public string Header { get; set; }
        public User User { get; set; }

    }
}
