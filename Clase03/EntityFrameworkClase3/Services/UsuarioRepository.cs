using EntityFrameworkClase3.Models;
using EntityFrameworkClase3.Data;

namespace EntityFrameworkClase3.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDBContext _context;

        public UsuarioRepository(UsuarioDBContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            Save();
        }

        public void Save() => _context.SaveChanges();

        public Usuario? GetById(int id) => _context.Usuarios.Find(id);
        public bool Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return true;
        }
    }
}