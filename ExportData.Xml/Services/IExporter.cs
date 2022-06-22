namespace ExportData.Xml.Services
{
    public interface IExporter<T>
    {
        Task ExportAsync(List<T> itemList, string filePath);
    }
}