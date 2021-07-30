using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Exceptions.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Services
{
    public class AlunoDomainService : BaseDomainService<AlunoEntity>, IAlunoDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public AlunoDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.AlunoRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public override void Create(AlunoEntity entity)
        {
            #region cpf deve ser único

            if (unitOfWork.AlunoRepository.Get(e => e.Cpf.Equals(entity.Cpf)) != null)
                throw new CpfDeveSerUnicoException(entity.Cpf);

            #endregion

            base.Create(entity);    
        }
    }
}
