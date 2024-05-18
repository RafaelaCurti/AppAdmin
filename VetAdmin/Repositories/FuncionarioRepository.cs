using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetAdmin.Context;
using VetAdmin.Interfaces;
using VetAdmin.Models;

namespace VetAdmin.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly AppDbContext _appDbContext;
        public FuncionarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Alterar(Funcionario funcionario)
        {
            _appDbContext.Entry(funcionario).State = EntityState.Modified;
        }

        public async Task<Funcionario> BuscarPorId(int id)
        {
            return await _appDbContext.Funcionario.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Excluir(Funcionario funcionario)
        {
            _appDbContext.Remove(funcionario);
        }

        public Task<IEnumerable<Funcionario>> Filtrar(Funcionario funcionario)
        {
            throw new System.NotImplementedException();
        }

        public void InlcuirFuncionario(Funcionario funcionario)
        {
            _appDbContext.Funcionario.Add(funcionario);
        }

        public async Task<IEnumerable<Funcionario>> Listar()
        {
            return await _appDbContext.Funcionario.ToListAsync();
        }

        public async Task<bool> SalvarAssincrono()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
