using ExportData.Data.Repository;
using ExportData.DialogService.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace ExportData.DialogService.Services
{
    internal class FileService<T> : IFileService<T> where T : class, IEntity, new()
    {
        public async Task<List<T>> ReadAsync(string filename)
        {
            List<T> items = new List<T>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                await Task.Run(() =>
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        T p = new T();
                        p.Inline(line);
                        items.Add(p);
                    }
                });
            }
            return items;
        }

    }
}
