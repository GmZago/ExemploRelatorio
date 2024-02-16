using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploRelatorio.Models
{
    [Table("Prescricao")]
    public class Prescricao
    {
        [Column("PrescricaoId")]
        [Display(Name = "Código Prescrição")]
        public int PrescricaoId { get; set;}

        [ForeignKey("ConsultaId")]
        public int ConsultaId { get; set; }
        public Consulta? Consulta { get; set; }

        [ForeignKey("MedicamentoId")]
        public int MedicamentoId { get; set; }
        public Medicamento? Medicamento { get; set; }

        [Column("Posologia")]
        [Display(Name ="Posologia")]
        public string Posologia { get; set; } = string.Empty;

    }
}
