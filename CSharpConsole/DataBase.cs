using Microsoft.EntityFrameworkCore;

namespace CSharpConsole
{
    public class DataBase : DbContext
    {
        public DbSet<Kontakter> Contacts { get; set; }
        public DbSet<Table2> Table2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //skriven med mycket hjälp av AI
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContactsDB;Integrated Security=True;");
        }
    }
}
