using CadastroVeiculos.Domain.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroVeiculos.Domain.Entities
{
    [Table("marca")]
    public class Marca : EntityBase
    {
        [Column("tx_nome")]
        public string Nome { get; set; }
        [Column("nb_status")]
        public Status Status { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
       
}
