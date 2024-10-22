using EjercicioCapas.Business.Entities;
using EjercicioCapas.Data.DTOs;

namespace EjercicioCapas.Business.Services
{
    public interface IBookService
    {
        int Insert(BookDTO dto);
        List<Book> GetBooksAll();
        List<Book> GetBooksByAutor(int autorId);

    }
}
