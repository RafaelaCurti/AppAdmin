using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetAdmin.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "A Profissão deve ter no máximo 50 caracteres.")]
        public string Profissao { get; set; }

        public int CanalDeComunicacaoEscolhido { get; set; } // Consider using an enum for communication channels

        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP inválido.")]
        public int CEP { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
