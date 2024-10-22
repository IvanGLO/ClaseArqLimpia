using EjercicioCapas.Business.Services;
using EjercicioCapas.Data.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioCapas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult Crear(BookDTO dto)
        {
            try
            {
                var res = _bookService.Insert(dto);
                return res > 0 ? Ok(res) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetBooksAll());
        }

        [HttpGet("ByAutor")]
        public IActionResult GetByAutor(int id)
        {
            return Ok(_bookService.GetBooksByAutor(id));
        }
    }
}
