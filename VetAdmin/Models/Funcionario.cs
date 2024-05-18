using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetAdmin.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        public bool EVeterinario { get; set; }

        public bool EAdministrativo { get; set; }

        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ inválido.")]
        public string CNPJ { get; set; }

        [MaxLength(50, ErrorMessage = "A Área deve ter no máximo 50 caracteres.")]
        public string Area { get; set; }

        [MaxLength(50, ErrorMessage = "A Especialidade deve ter no máximo 50 caracteres.")]
        public string Especialidade { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
