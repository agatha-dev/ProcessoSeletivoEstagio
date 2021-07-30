using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<TurmaEntity>
    {
        public void Configure(EntityTypeBuilder<TurmaEntity> builder)
        {
            //nome da tabela
            builder.ToTable("Turma");

            //chave primária
            builder.HasKey(e => e.Id);

            //campos
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.NomeCurso)
                .HasColumnName("NomeCurso")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.NomeProfessor)
                .HasColumnName("NomeProfessor")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.DataInicio)
                .HasColumnName("DataInicio")
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
