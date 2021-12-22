using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "O campo Id é obrigatorio")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        [EmailAddress(ErrorMessage = "Email em formato invalido")]
        [StringLength(100, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        public string Email { get; set; }
    }
}
