using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        [Route("StaticPdfReport")]
        public IActionResult StaticPdfReport()
        {
            string path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/PdfReports/"+"dosya1.pdf");
            var stream=new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);//pdf oluştu ama içini doldurmadık

            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Reservation Pdf Report");
            document.Add(paragraph);
            document.Close();

            return File("/PdfReports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
        [Route("StaticCustomerReport")]
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            string arial = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(arial, BaseFont.IDENTITY_H, true);
            Font font = new Font(baseFont, 12, Font.NORMAL);


            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);//pdf oluştu ama içini doldurmadık

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);//3 satır
            pdfPTable.AddCell(new Phrase("Guest Name",font));
            pdfPTable.AddCell(new Phrase("Guest Surname", font));
            pdfPTable.AddCell(new Phrase("Guest ID number", font));

            pdfPTable.AddCell(new Phrase("Buse",font));
            pdfPTable.AddCell(new Phrase("Duran",font));
            pdfPTable.AddCell(new Phrase("11111111111", font));

            pdfPTable.AddCell(new Phrase("Kaan", font));
            pdfPTable.AddCell(new Phrase("Balcı Duran", font));
            pdfPTable.AddCell(new Phrase("00000000000", font));

            document.Add(pdfPTable);
            document.Close();
            return File("/PdfReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
