using System.Collections.Generic;
using System.Threading.Tasks;
using VetAdmin.Models;

namespace VetAdmin.Interfaces
{
    public interface IUsuarioRepository
    {
        //Task<>
        void InlcuirUsuario(Usuario usuario);
        void Alterar(Usuario usuario);
        void Excluir(Usuario usuario);
        Task<IEnumerable<Usuario>> Listar();  
        Task<Usuario> BuscarPorId(int id);
        Task<IEnumerable<Usuario>> Filtrar(Usuario usuario);
        Task<bool> SalvarAssincrono();
    }
}
