using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Entities
{
    public class TurmaEntity
    {
        public Guid Id { get; set; }
        public string NomeCurso { get; set; }
        public string NomeProfessor { get; set; }
        public DateTime DataInicio { get; set; }

        #region Relacionamentos

        public ICollection<AlunoEntity> Alunos { get; set; }

        #endregion
    }
}
