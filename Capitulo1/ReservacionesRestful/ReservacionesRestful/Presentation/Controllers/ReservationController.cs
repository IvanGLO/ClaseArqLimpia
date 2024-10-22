using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservacionesRestful.Business.Services;
using ReservacionesRestful.Data.DTOs;

namespace ReservacionesRestful.Presentation.Controllers
{
    //POST -> insert
    //PUT -> Actualizacion 
    //PATCH -> Actualizacion parcial 
    //GET -> Consulta 

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult Create(ReservationDTO dto)
        {
            try
            {
                var res = _reservationService.Insert(dto);
                return res > 0 ? Ok(res) : BadRequest();
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_reservationService.GetAll());
        }

        [HttpGet("rooms")]
        public IActionResult GetAvailableRooms()
        {
            return Ok(_reservationService.GetAvailableRooms());
        }
    }
}
