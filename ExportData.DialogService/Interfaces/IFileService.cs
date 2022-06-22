using ExportData.Data.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExportData.DialogService.Interfaces
{
    public interface IFileService<T> where T : class, IEntity
    {
        public Task<List<T>> ReadAsync(string filename);

    }
}
