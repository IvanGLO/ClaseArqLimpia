using ReservacionesRestful.Business.Entities;
using ReservacionesRestful.Data.DTOs;

namespace ReservacionesRestful.Business.Services
{
    public interface IReservationService
    {
        List<Reservation> GetAll();
        int Insert(ReservationDTO dto);
        List<Room> GetAvailableRooms();

    }
}
