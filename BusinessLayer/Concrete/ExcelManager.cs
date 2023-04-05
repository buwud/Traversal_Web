using BusinessLayer.Abstract;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExcelList<T>(List<T> t) where T : class
        {
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Page 1");

            worksheet.Cells["A1"].LoadFromCollection(t, true, OfficeOpenXml.Table.TableStyles.Dark5);

            return excel.GetAsByteArray();
        }
    }
}
