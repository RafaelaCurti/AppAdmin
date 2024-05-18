using System.Collections.Generic;
using System.Threading.Tasks;
using VetAdmin.Models;

namespace VetAdmin.Interfaces
{
    public interface IFuncionarioRepository
    {
        //Task<>
        void InlcuirUsuario(Funcionario funcionario);
        void Alterar(Funcionario funcionario);
        void Excluir(Funcionario funcionario);
        Task<IEnumerable<Funcionario>> Listar();
        Task<Funcionario> BuscarPorId(int id);
        Task<IEnumerable<Funcionario>> Filtrar(Funcionario funcionario);
        Task<bool> SalvarAssincrono();
    }
}
