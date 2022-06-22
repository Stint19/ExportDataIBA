using ExportData.Data.Repository;

namespace ExportData.Data.Models
{
    public class Person : IEntity
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public void Inline(string line)
        {
            string[] parts = line.Split(';');
            Date = Convert.ToDateTime(parts[0]);
            FirstName = parts[1];
            LastName = parts[2];
            SurName = parts[3];
            City = parts[4];
            Country = parts[5];
        }
    }
}
