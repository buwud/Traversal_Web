using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(mailRequest.Name,mailRequest.Sender);//kimden gönderilcek
            mimeMessage.From.Add(mailboxAddressFrom);
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.Receiver);

            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mimeMessage.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smptp.gmail.com", 587, false);
            client.Authenticate(mailRequest.Sender, "123456Bb*");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
