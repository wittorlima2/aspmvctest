using CadastroVeiculos.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroVeiculos.Domain.Entities
{
    [Table("veiculo")]
    public class Veiculo : EntityBase
    {
        public Guid ProprietarioId { get; set; }
        [ForeignKey("proprietario_id")]
        public virtual Proprietario Proprietario { get; set; }
        [ForeignKey("marca_id")]
        public virtual Marca Marca { get; set; }
        public Guid MarcaId { get; set; }
        [Column("tx_renavam")]
        public string RENAVAM { get; set; }
        [Column("tx_modelo")]
        public string  Modelo { get; set; }
        [Column("nb_ano_fabricacao")]
        public int  AnoFabricacao { get; set; }
        [Column("nb_ano_modelo")]
        public int AnoModelo { get; set; }
        [Column("nb_quilometragem")]
        public int Quilometragem { get; set; }
        [Column("nb_valor")]
        public decimal Valor { get; set; }
        [Column("nb_status")]
        public StatusVeiculo Status { get; set; }
    }
}
