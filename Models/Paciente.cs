using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploRelatorio.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [Column("PacienteId")]
        [Display(Name = "Código do Paciente")]
        public int PacienteId { get; set; }

        [Column("NomePaciente")]
        [Display(Name = "Nome do Paciente")]
        public string NomePaciente { get; set; } = string.Empty;
    }
}
