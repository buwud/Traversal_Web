using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using Traversal.Models;

namespace Traversal.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult StaticExcelReport()
        {
            List<DestinationModel> destinationList = DestinationModel.DestinationList();
            return File(_excelService.ExcelList(destinationList), "application/vnd.openxmlformants-officedocument.spreadsheetml.sheet", Guid.NewGuid().ToString() + ".xlsx");
        }
        public IActionResult DestinationExcelReport(DestinationModel m)
        {
            List<DestinationModel> destinationList = DestinationModel.DestinationList();
            Guid guid = Guid.NewGuid();
            using(var workBook= new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tour List");
                workSheet.Cell(1, 1).Value = "City";
                workSheet.Cell(1, 2).Value = "Duration";
                workSheet.Cell(1, 3).Value = "Price";
                workSheet.Cell(1, 4).Value = "Capacity";

                int rowCount = 2;
                foreach(var item in destinationList)
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
