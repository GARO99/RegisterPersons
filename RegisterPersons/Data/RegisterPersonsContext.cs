using Microsoft.EntityFrameworkCore;
using RegisterPersons.Models;

namespace RegisterPersons.Data
{
    public class RegisterPersonsContext : DbContext
    {
        public RegisterPersonsContext(DbContextOptions<RegisterPersonsContext> options) : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
