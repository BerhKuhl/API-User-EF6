using usuario.Model;

namespace usuario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDBContext _context;

        public UsuarioRepository(UsuarioDBContext context)
        {
            _context = context;
        }

        public void AdicionaUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }

        public async Task<Usuario> BuscaUsuario(int id)
        {
            return await _context.Usuarios.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> BuscaUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public void DeletaUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}