using System.Collections.Generic;
using System.Threading.Tasks;
using VetAdmin.Models;

namespace VetAdmin.Interfaces
{
    public interface IClienteRepository
    {
        void InlcuirUsuario(Cliente cliente);
        void Alterar(Cliente cliente);
        void Excluir(Cliente cliente);
        Task<IEnumerable<Cliente>> Listar();
        Task<Cliente> BuscarPorId(int id);
        Task<IEnumerable<Cliente>> Filtrar(Cliente cliente);
        Task<bool> SalvarAssincrono();
    }
}
