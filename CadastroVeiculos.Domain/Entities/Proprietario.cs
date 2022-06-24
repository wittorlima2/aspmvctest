using CadastroVeiculos.Domain.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroVeiculos.Domain.Entities
{
    [Table("proprietario")]
    public class Proprietario : EntityBase
    {
        [Column("tx_nome")]
        public string Nome { get; set; }
        [Column("nb_status")]
        public Status Status { get; set; }
        [Column("tx_documento")]
        public string Documento { get; set; }
        [Column("tx_email")]
        public string Email { get; set; }
        [Column("nb_cep")]
        public int Cep { get; set; }
        [Column("tx_endereco")]
        public string Endereco { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
