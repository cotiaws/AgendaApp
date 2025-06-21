using AgendaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Tarefa
    /// </summary>
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Data).IsRequired();
            builder.Property(t => t.Hora).IsRequired();
            builder.Property(t => t.Prioridade).IsRequired();
            builder.Property(t => t.Ativo).IsRequired();

            builder.HasOne(t => t.Usuario) //Tarefa PERTENCE A 1 Usuário
                .WithMany(u => u.Tarefas) //Usuario POSSUI muitas Tarefas
                .HasForeignKey(t => t.UsuarioId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //Tipo de exclusão
        }
    }
}
