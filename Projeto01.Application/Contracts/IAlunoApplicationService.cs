using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Aluno;
using System;
using System.Collections.Generic;

namespace Projeto01.Application.Contracts
{
    public interface IAlunoApplicationService : IDisposable
    {
        AlunoDTO Create(AlunoCadastroModel model);
        AlunoDTO Update(AlunoEdicaoModel model);
        AlunoDTO Delete(Guid id);

        List<AlunoDTO> GetAll();
        AlunoDTO GetById(Guid id);
    }
}
