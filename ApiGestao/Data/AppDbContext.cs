using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGestao.Models;

namespace ApiGestao.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Sala> Sala { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Agendamento

            modelBuilder.Entity<Agendamento>()
        .HasKey(c => new { c.IDAGENDAMENTO });

            modelBuilder.Entity<Agendamento>()
             .Property(a => a.TITULO).HasMaxLength(100);

            modelBuilder.Entity<Agendamento>()
                .HasData(
                new Agendamento { IDAGENDAMENTO = 1, TITULO = "Definir Scrum com Equipe", DT_INICIO = new DateTime(2021, 03, 24, 07,00,00), DT_FIM = new DateTime(2021, 03, 24, 11,20,00), IDSALA = 1},
                new Agendamento { IDAGENDAMENTO = 2, TITULO = "Homologação dos requisitos com o cliente", DT_INICIO = new DateTime(2021, 03, 25, 13,00,00), DT_FIM = new DateTime(2021, 03, 25, 15,00,00), IDSALA = 2},
                new Agendamento { IDAGENDAMENTO = 3, TITULO = "contratação candidato", DT_INICIO = new DateTime(2021, 03, 26, 09, 00, 00), DT_FIM = new DateTime(2021, 03, 26, 10, 30, 00), IDSALA = 3});
            #endregion

            #region Salas
            modelBuilder.Entity<Sala>()
        .HasKey(c => new { c.IDSALA });

            modelBuilder.Entity<Sala>()
              .Property(a => a.NOME).HasMaxLength(50);

            modelBuilder.Entity<Sala>()
               .HasData(
               new Sala { IDSALA = 1, NOME = "Reuniao Equipe Dev" },
               new Sala { IDSALA = 2, NOME = "Departamento Pessoal" },
               new Sala { IDSALA = 3, NOME = "Entrevistas" });

            #endregion

        }


    }
}
