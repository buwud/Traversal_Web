namespace Traversal.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResults
    {
        //isimlendirmeler databasedekinden farklı olabilir
        public int id { get; set; }
        public string? city { get; set; }
        public double price { get; set; }
        public string? duration  { get; set; }
        public int capacity  { get; set; }
    }
}
