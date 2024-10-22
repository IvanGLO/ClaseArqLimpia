using EjercicioCapas.Business.Entities;

namespace EjercicioCapas.Data.Repositories
{
    public class AutorRepository
    {
        private readonly AppDBContext _dbContext;

        public AutorRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
            _dbContext.Database.EnsureCreated();
        }

        public int Insert(Autor autor)
        {
            throw new NotImplementedException();
        }

        public Autor FindById(int id)
        {
            var result = _dbContext.Autors.Find(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception($"Autor {id} no existe!");
            }
        }

    }
}
