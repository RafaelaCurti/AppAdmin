using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetAdmin.Context;
using VetAdmin.Interfaces;
using VetAdmin.Models;

namespace VetAdmin.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _appDbContext;
        public ClienteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Alterar(Cliente cliente)
        {
            _appDbContext.Entry(cliente).State = EntityState.Modified;
        }

        public async Task<Cliente> BuscarPorId(int id)
        {
            return await _appDbContext.Cliente.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Excluir(Cliente cliente)
        {
            _appDbContext.Remove(cliente);
        }

        public Task<IEnumerable<Cliente>> Filtrar(Cliente cliente)
        {
            throw new System.NotImplementedException();
        }

        public void InlcuirUsuario(Cliente cliente)
        {
            _appDbContext.Cliente.Add(cliente);
        }

        public async Task<IEnumerable<Cliente>> Listar()
        {
            return await _appDbContext.Cliente.ToListAsync();
        }

        public async Task<bool> SalvarAssincrono()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
