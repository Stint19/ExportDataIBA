using System.Xml.Serialization;

namespace ExportData.Xml.Services
{
    public class XmlExporter<T> : IXmlExporter<T>
    {
        public async Task ExportAsync(List<T> itemList, string filePath)
        {
            await Task.Run(() =>
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, itemList);
                }
            });
        }
    }
}
