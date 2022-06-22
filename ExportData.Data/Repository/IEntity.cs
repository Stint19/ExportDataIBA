using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportData.Data.Repository
{
    public interface IEntity
    {
        public int? Id { get; set; }

        public void Inline(string line);
    }
}
