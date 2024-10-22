using System.Text.Json.Serialization;

namespace EjercicioCapas.Business.Entities
{
    public class Autor
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Nationality { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
        public Autor()
        {
            
        }
    }
}
