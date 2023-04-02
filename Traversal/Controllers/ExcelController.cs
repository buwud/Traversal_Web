using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Traversal.Models;

namespace Traversal.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using(var context=new Context())
            {
                destinationModels = context.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.StayTime,
                    Capacity = x.Capacity
                }).ToList();

            }
            return destinationModels;
        }
        public IActionResult StaticExcelReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Page-1");
            worksheet.Cells[1, 1].Value = "Route";
            worksheet.Cells[1, 2].Value = "Guide";
            worksheet.Cells[1, 3].Value = "Capacity";

            worksheet.Cells[2, 1].Value = "Gürcistan-Batum";
            worksheet.Cells[2, 2].Value = "Buse Duran";
            worksheet.Cells[2, 3].Value = "390";

            worksheet.Cells[2, 1].Value = "Sırbşstan-Makedonya";
            worksheet.Cells[2, 2].Value = "Kaan Balcı Duran";
            worksheet.Cells[2, 3].Value = "325";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformants-officedocument.spreadsheetml.sheet", "File1.xlsx");

        }
        public IActionResult DestinationExcelReport()
        {
            Guid guid = Guid.NewGuid();
            using(var workBook= new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tour List");
                workSheet.Cell(1, 1).Value = "City";
                workSheet.Cell(1, 2).Value = "Duration";
                workSheet.Cell(1, 3).Value = "Price";
                workSheet.Cell(1, 4).Value = "Capacity";

                int rowCount = 2;
                foreach(var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;

                    rowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformants-officedocument.spreadsheetml.sheet", guid.ToString() + ".xlsx");
                }
            }
        }
    }
}
