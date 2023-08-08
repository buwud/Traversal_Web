namespace SignalRAPI.Models
{
    public class VisitorChart
    {
        public VisitorChart()
        {
            Counters = new List<int>();
        }

        public string Date { get; set; }
        public List<int> Counters { get; set; }
    }
}
