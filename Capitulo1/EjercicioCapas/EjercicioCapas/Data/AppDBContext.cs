using EjercicioCapas.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjercicioCapas.Data
{
    public class AppDBContext: DbContext
    {
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //PK
            modelBuilder.Entity<Autor>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Book>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

           
            //FK
            modelBuilder.Entity<Autor>()
                .HasMany(t => t.Books)
                .WithOne(t => t.Autor)
                .HasForeignKey(t => t.AutorId);

            base.OnModelCreating(modelBuilder);
        }

        public AppDBContext() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
    }
}
