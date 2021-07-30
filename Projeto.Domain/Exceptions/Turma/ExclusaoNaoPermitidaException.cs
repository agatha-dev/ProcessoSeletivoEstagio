using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Exceptions.Turma
{
    public class ExclusaoNaoPermitidaException : Exception
    {
        //atributo
        private int numAluno;

        //construtor para inicialização
        public ExclusaoNaoPermitidaException(int numAluno)
        {
            this.numAluno = numAluno;
        }

        public override string Message
            => $"Não é permitido excluir a turma pois ela possui {numAluno} Aluno(s).";
    }
}
