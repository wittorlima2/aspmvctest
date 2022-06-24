using CadastroVeiculos.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroVeiculos.Models
{
    public class ProprietarioViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo 2 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo Documento")]
        public string Documento { get; set; }
        [Required(ErrorMessage = "Preencha o campo Email")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Preencha o campo Cep")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Somente Números")]
        [Range(1,99999999)]
        public int Cep { get; set; }
        [Required(ErrorMessage = "Preencha o campo Endereco")]
        public string Endereco { get; set; }
        public Status Status { get; set; }
       
        public string StatuDesc
        {
            get
            {
                switch (Status)
                {
                    case Status.Cancelado:
                        return "Cancelado";
                    case Status.Ativo:
                        return "Ativo";
                    default:
                        return "Status não indenficado";
                }
            }
        }
    }
}
