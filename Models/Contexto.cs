using Microsoft.EntityFrameworkCore;

namespace ExemploRelatorio.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Consulta> Consulta { get; set; }

        public DbSet<Medicamento> Medicamento { get; set; }

        public DbSet<Prescricao> Prescricao { get; set; }
    }
}
