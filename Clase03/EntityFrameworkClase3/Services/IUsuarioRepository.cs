using EntityFrameworkClase3.Models;

namespace EntityFrameworkClase3.Services
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        void Save();

        Usuario? GetById(int id);

        bool Delete(int id);
    }
}