using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

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
