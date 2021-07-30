using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<AlunoEntity>
    {
        public void Configure(EntityTypeBuilder<AlunoEntity> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("Id");

            builder.Property(f => f.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Sexo)
                .HasColumnName("Sexo")
                .IsRequired();

            builder.Property(f => f.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
                .IsRequired();


            builder.Property(f => f.TurmaId)
                .HasColumnName("TurmaId")
                .IsRequired();

            #region Relacionamentos

            builder.HasOne(f => f.Turma) //Aluno TEM 1 Turma
                .WithMany(e => e.Alunos) //Turma TEM N Alunos
                .HasForeignKey(f => f.TurmaId); //Chave estrangeira

            #endregion
        }
    }
}
