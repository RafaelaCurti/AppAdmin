using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetAdmin.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Login é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Login deve ter no máximo 10 caracteres.")]
        [MinLength(4, ErrorMessage = "O Login deve ter no mínimo 4 caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MaxLength(10, ErrorMessage = "A Senha deve ter no máximo 10 caracteres.")]
        [MinLength(4, ErrorMessage = "A Senha deve ter no mínimo 4 caracteres.")]
        [PasswordPropertyText] // Assuming this is a custom attribute
        public string Senha { get; set; }

        [MaxLength(50, ErrorMessage = "O Nome deve ter no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [DataType(DataType.Date)] // Consider using appropriate date format for your region
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.DateTime)] // Consider using appropriate datetime format for your region
        public DateTime DataCriacao { get; set; }

        [DataType(DataType.DateTime)] // Consider using appropriate datetime format for your region
        public DateTime DataAtualizacao { get; set; }

        public int Codigo { get; set; }

        public int Status { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }

        public string RG { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [Phone]
        public string Celular { get; set; }

        public int Sexo { get; set; }

        [MinLength(15, ErrorMessage = "O Endereço deve ter no mínimo 15 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Endereço deve ter no máximo 100 caracteres.")]
        public string Endereco { get; set; }

        [MinLength(5, ErrorMessage = "O Bairro deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "O Bairro deve ter no máximo 50 caracteres.")]
        public string Bairro { get; set; }

        [MaxLength(50, ErrorMessage = "A Cidade deve ter no máximo 50 caracteres.")]
        [MinLength(3, ErrorMessage = "A Cidade deve ter no mínimo 3 caracteres.")]
        public string Cidade { get; set; }

        [MaxLength(50, ErrorMessage = "O Estado deve ter no máximo 50 caracteres.")]
        [MinLength(2, ErrorMessage = "O Estado deve ter no mínimo 2 caracteres.")]
        public string Estado { get; set; }

        public int EstadoCivil { get; set; }

        // Relacionamento com Cliente (1 para 1)
        public Cliente Cliente { get; set; }

        // Relacionamento com Funcionário (1 para 1)
        public Funcionario Funcionario { get; set; }
    }
}
