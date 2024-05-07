namespace perkmaker_backend.Models
{
    public class SurvivorEntry: Entry
    {
        public SurvivorEntry(string header, Survivor survivor): base(header, EntryType.Survivor)
        {
            Survivor = survivor;
        }
        protected SurvivorEntry() { }
        public Survivor Survivor { get; set; }
    }
}
