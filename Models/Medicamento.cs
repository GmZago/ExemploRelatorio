using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploRelatorio.Models
{
    [Table("Medicamento")]
    public class Medicamento
    {
        [Column("MedicamentoId")]
        [Display(Name="Código Medicamento")]
        public int MedicamentoId { get; set; }

        [Column("NomeMedicamento")]
        [Display(Name="Nome Medicamento")]
        public string MedicamentoNome { get; set; } = string.Empty;
    }
}
