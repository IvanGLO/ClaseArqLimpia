using Microsoft.EntityFrameworkCore;
using ReservacionesRestful.Business.Entities;

namespace ReservacionesRestful.Data.Repositories
{
    public class ReservationRepository
    {
        private readonly AppDBContext _dbContext;

        public ReservationRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            var result = _dbContext.SaveChanges();
            return result;
        }

        public Reservation FindById(int id)
        {
            var result = _dbContext.Reservations.Find(id);
            return result ?? throw new Exception($"No existe la reservación {id}!");
        }

        public List<Reservation> GetAll()
        {
            return _dbContext.Reservations
                .Include(i => i.User)
                .Include(i => i.Room)
                .ToList();
        }
    }
}
