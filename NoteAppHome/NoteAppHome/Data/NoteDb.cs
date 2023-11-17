using Microsoft.EntityFrameworkCore;

namespace NoteAppHome.Data
{
    public class NoteDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=NoteDB;uid=sa;pwd=sa;Trust Server Certificate=true");
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<NoteBook> NoteBooks { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
