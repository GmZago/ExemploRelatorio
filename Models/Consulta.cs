using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploRelatorio.Models
{
    [Table("Consulta")]
    public class Consulta
    {
        [Column("ConsultaId")]
        [Display(Name ="Código da Consulta")]
        public int ConsultaId { get; set; }

        [ForeignKey("MedicoId")]
        public int MedicoId { get; set; }
        public Medico? Medico { get; set; }

        [ForeignKey("PacienteId")]
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        [Column("DataConsulta")]
        [Display(Name ="Data da Consulta")]
        public DateTime DataConsulta { get; set; }

        [NotMapped]
        public List<Prescricao>? Prescricao { get; set; }

    }
}
