using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploRelatorio.Models
{
    [Table("Medico")]
    public class Medico
    {
        [Column("MedicoId")]
        [Display(Name = "Código do Medico")]
        public int MedicoId { get; set; }

        [Column("MedicoNome")]
        [Display(Name = "Nome do Medico")]
        public string MedicoNome { get; set; } = string.Empty;

    }
}
