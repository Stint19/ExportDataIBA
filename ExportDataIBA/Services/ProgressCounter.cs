using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportData.UI.Services
{
    internal class ProgressCounter
    {
        private readonly int total;
        private int count;
        private int lastPercentage;

        public ProgressCounter(int total)
        {
            this.total = total;
        }

        public void Update()
        {
            count++;
            int currentPercentage = (count * 100) / total;
            if (currentPercentage != lastPercentage)
            {
                Console.WriteLine("Done {0}%", currentPercentage);
                lastPercentage = currentPercentage;
            }
            return;
        }
    }
}
