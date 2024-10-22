using EjercicioCapas.Business.Entities;
using EjercicioCapas.Data.DTOs;
using EjercicioCapas.Data.Repositories;

namespace EjercicioCapas.Business.Services
{
    public class BookServiceImpl : IBookService
    {
        private readonly BookRepository _bookRepository;
        private readonly AutorRepository _authorRepository;

        public BookServiceImpl(BookRepository bookRepository, AutorRepository autorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = autorRepository;
        }

        public List<Book> GetBooksAll()
        {
            return _bookRepository.GetAll();
        }

        public List<Book> GetBooksByAutor(int autorId)
        {
            return _bookRepository.GetAll().Where(w => w.Autor.Id == autorId).ToList();
        }

        public int Insert(BookDTO dto)
        {
            //Busqueda de usuario
            var autor = new Autor();
            try
            {
                autor = _authorRepository.FindById(dto.AutorId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            Book book = new Book() { 
                    AutorId = dto.AutorId,
                    Description = dto.Description,
                    Name = dto.Name,
            };

            var res = _bookRepository.Insert(book);
            return res;
        }
    }
}
