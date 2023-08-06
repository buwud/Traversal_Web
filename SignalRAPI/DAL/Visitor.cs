namespace SignalRAPI.DAL
{
    public enum Ecity
    {
        Berlin = 1,
        İstanbul = 2,
        Ankara = 3,
        Kayseri = 4,
        Maraş = 5

    }
    public class Visitor
    {
        public int visitorID { get; set; }
        public Ecity ecity { get; set; }
        public int cityVisitorCount { get; set; }
        public DateTime dateTime  { get; set; }
    }
}
