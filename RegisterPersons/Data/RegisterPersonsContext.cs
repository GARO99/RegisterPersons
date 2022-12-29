using Microsoft.EntityFrameworkCore;

namespace RegisterPersons.Data
{
    public class RegisterPersonsContext : DbContext
    {
        public RegisterPersonsContext(DbContextOptions<RegisterPersonsContext> options): base(options)
        { }
    }
}
