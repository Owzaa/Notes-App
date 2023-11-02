using Microsoft.EntityFrameworkCore;

namespace Notes.Models
{
    public class NotesContext
    {
        public object NotesModel { get; internal set; }
        public object Notes { get; internal set; }

        internal object Entry(NotesModel note)
        {
            throw new NotImplementedException();
        }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public class NoteContext : DbContext
        {
            public DbSet<NotesModel>? Notes { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NotesDB;Trusted_Connection=True;");
            }
        }
    }



}

