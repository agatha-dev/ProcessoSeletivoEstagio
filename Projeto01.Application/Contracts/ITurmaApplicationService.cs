using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Empresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.Contracts
{
    public interface ITurmaApplicationService : IDisposable
    {
        TurmaDTO Create(TurmaCadastroModel model);
        TurmaDTO Update(TurmaEdicaoModel model);
        TurmaDTO Delete(Guid id);

        List<TurmaDTO> GetAll();
        TurmaDTO GetById(Guid id);
    }
}
