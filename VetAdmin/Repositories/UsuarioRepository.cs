using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetAdmin.Context;
using VetAdmin.Interfaces;
using VetAdmin.Models;

namespace VetAdmin.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IFuncionarioRepository _funcionario;
        private readonly IClienteRepository _cliente;
        public UsuarioRepository(AppDbContext appDbContext, IFuncionarioRepository funcionario, IClienteRepository cliente)
        {
            _appDbContext = appDbContext;
            _funcionario = funcionario;
            _cliente = cliente;
        }
        public void Alterar(Usuario usuario)
        {
            _appDbContext.Entry(usuario).State = EntityState.Modified;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _appDbContext.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Excluir(Usuario usuario)
        {
            _appDbContext.Remove(usuario);
        }

        public async Task<IEnumerable<Usuario>> Filtrar(Usuario usuario)
        {
            var query = _appDbContext.Usuario.AsQueryable();

            if (!string.IsNullOrEmpty(usuario.Login))
            {
                query = query.Where(u => u.Login.Contains(usuario.Login));
            }

            if (!string.IsNullOrEmpty(usuario.Senha))
            {
                query = query.Where(u => u.Senha.Contains(usuario.Senha));
            }

            var filteredUsuario = query.ToList();

            return filteredUsuario;
        }


        public void InlcuirUsuario(Usuario usuario)
        {
            _appDbContext.Usuario.Add(usuario);
        }

        public async Task<IEnumerable<Usuario>> Listar()
        {
            var usuariosComRelacionamentos = await _appDbContext.Usuario
               .Include(u => u.Funcionario)
               .Include(u => u.Cliente)
               .ToListAsync();

            return usuariosComRelacionamentos;
           
        }

        public async Task<bool> SalvarAssincrono()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
