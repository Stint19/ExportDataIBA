using ClosedXML.Excel;

namespace ExportData.Excel.Services
{
    public class ExcelExporter<T> : IExcelExporter<T>
    {
        public async Task ExportAsync(List<T> itemList, string filePath)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Persons");
            var currentRow = 1;
            var currentCell = 1;
            Type type = typeof(T);

            await Task.Run(() =>
            {
                foreach (var item in itemList)
                {
                    foreach(var property in type.GetProperties())
                    {
                        worksheet.Cell(currentRow, currentCell).Value = property.GetValue(item);
                        currentCell++;
                    }
                    currentCell = 1;
                    currentRow++;
                }
            });

            workbook.SaveAs(filePath);
        }
    }
}
