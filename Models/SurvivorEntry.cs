namespace perkmaker_backend.Models
{
    public class SurvivorEntry: Entry
    {
        public SurvivorEntry(string header, Survivor survivor, User user) : base(header, EntryType.Survivor, user)
        {
            Survivor = survivor;
        }
        protected SurvivorEntry() { }
        public Survivor Survivor { get; set; }
    }
}
