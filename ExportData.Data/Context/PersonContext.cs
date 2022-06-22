using ExportData.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExportData.Data
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null;
        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
