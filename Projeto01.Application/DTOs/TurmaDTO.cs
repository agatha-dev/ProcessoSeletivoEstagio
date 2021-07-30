using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.DTOs
{
    public class TurmaDTO
    {
        public Guid Id { get; set; }
        public string NomeCurso { get; set; }
        public string NomeProfessor { get; set; }
        public DateTime DataInicio { get; set; }
    }
}
