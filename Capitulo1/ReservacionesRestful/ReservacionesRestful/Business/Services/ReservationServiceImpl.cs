using ReservacionesRestful.Business.Entities;
using ReservacionesRestful.Data.DTOs;
using ReservacionesRestful.Data.Repositories;

namespace ReservacionesRestful.Business.Services
{
    public class ReservationServiceImpl: IReservationService
    {
        private readonly RoomRepository _roomRepository;
        private readonly ReservationRepository _reservationRepository;
        private readonly UserRepository _userRepository;

        public ReservationServiceImpl(RoomRepository roomRepository, ReservationRepository reservationRepository, UserRepository userRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
        }

        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

        public List<Room> GetAvailableRooms()
        {
            return _roomRepository.GetAvailable();
        }

        public int Insert(ReservationDTO dto)
        {
            //Busqueda de usuario
            var user = new User();
            try
            {
                user = _userRepository.FindById(dto.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            //busqueda de room
            var room = new Room();
            try
            {
                room = _roomRepository.FindById(dto.RoomId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            if (room.Available)
            {
                Reservation reservation = new Reservation(dto.UserId, dto.RoomId, dto.Begin, dto.End);
                
                var res = _reservationRepository.Insert(reservation);
                room.Available = false;
                _roomRepository.Update(room);
                return res;
            }
            else
            {
                throw new Exception($"Habitación no disponible {room.RoomId}");
            }

        }
    }
}
