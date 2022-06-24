using CadastroVeiculos.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroVeiculos.Models
{
    public class VeiculoViewModel
    {
        public Guid Id { get; set; }
        public virtual ProprietarioViewModel Proprietario { get; set; }
        public virtual MarcaViewModel Marca { get; set; }
        public Guid ProprietarioId { get; set; }
        public Guid MarcaId { get; set; }
        [Required(ErrorMessage = "Preencha o campo RENAVAM")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo 2 caracteres")]
        public string RENAVAM { get; set; }
        [Required(ErrorMessage = "Preencha o campo Modelo")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo 2 caracteres")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Preencha o campo AnoFabricacao")]
        public int AnoFabricacao { get; set; }
        [Required(ErrorMessage = "Preencha o campo AnoModelo")]
        public int AnoModelo { get; set; }
        [Required(ErrorMessage = "Preencha o campo Quilometragem")]
        public int Quilometragem { get; set; }
        [Required(ErrorMessage = "Preencha o campo Valor")]
        public decimal Valor { get; set; }
        public StatusVeiculo Status { get; set; }
    }
}
