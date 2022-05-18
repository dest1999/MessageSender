using Microsoft.EntityFrameworkCore;

namespace MessageSenderMVC;

public class MSSQLLocalDBContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public MSSQLLocalDBContext(DbContextOptions<MSSQLLocalDBContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
