using Microsoft.EntityFrameworkCore;
using ReservacionesRestful.Business.Entities;

namespace ReservacionesRestful.Data
{
    /*Esta clase representa al contexto (conexion a la base de datos). */
    public class AppDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        public AppDBContext(){}
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            
            //optionsBuilder.UseMySQL("server=localhost; port:3306");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            
            //PK
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Room>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Reservation>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //FK
            modelBuilder.Entity<Room>()
                .HasMany(t => t.Reservations)
                .WithOne(t => t.Room)
                .HasForeignKey(t => t.RoomId);



            base.OnModelCreating(modelBuilder);
        }
    }
}
