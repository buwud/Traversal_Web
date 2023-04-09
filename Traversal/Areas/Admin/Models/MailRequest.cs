namespace Traversal.Areas.Admin.Models
{
    public class MailRequest
    {
        public string? Name { get; set; }
        public string? Sender { get; set; }
        public string? Receiver { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
