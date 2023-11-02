using Microsoft.EntityFrameworkCore;

namespace Notes.Models
{
    public class NotesContext
    {

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

