using EjercicioCapas.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace EjercicioCapas.Data.Repositories
{
    public class BookRepository
    {
        private readonly AppDBContext _dbContext;

        public BookRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(Book book)
        {
            _dbContext.Books.Add(book);
            var result = _dbContext.SaveChanges();

            return result;
        }

        public Book FindById(int id)
        {
            var result = _dbContext.Books.Find(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception($"Libro {id} no existe!");
            }
        }

        public List<Book> GetAll()
        {
            return _dbContext.Books
                .Include(i => i.Autor)
                .ToList();
        }
    }
}
