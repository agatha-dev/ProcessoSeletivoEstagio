using Projeto01.Domain.Entities;
using Projeto01.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.DTOs
{
    public class AlunoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public SexoEnum Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public Guid TurmaId { get; set; }
        public TurmaEntity Turma { get; set; }

    }
}
