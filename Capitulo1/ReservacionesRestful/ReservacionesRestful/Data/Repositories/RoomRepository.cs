using ReservacionesRestful.Business.Entities;

namespace ReservacionesRestful.Data.Repositories
{
    public class RoomRepository
    {
        private readonly AppDBContext _dbContext;

        public RoomRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(Room room)
        {
            _dbContext.Rooms.Add(room);
            var result = _dbContext.SaveChanges(); 
            return result;
        }

        public Room FindById(int id)
        {
            var room = _dbContext.Rooms.Find(id);
            return room ?? throw new Exception($"No existe el room {id}!!");
        }

        public int Update(Room room)
        {
            var rsearch = _dbContext.Rooms.Find(room.Id);
            if (rsearch != null)
            {
                _dbContext.Rooms.Update(rsearch);
                return _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception($"No existe el room {room.Id}");
            }
        }

        public List<Room> GetAvailable()
        {
            return _dbContext.Rooms.Where(w=>w.Available==true).ToList();
        }
    }
}
