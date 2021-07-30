using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Exceptions.Turma;

namespace Projeto01.Domain.Services
{
    public class TurmaDomainService : BaseDomainService<TurmaEntity>, ITurmaDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public TurmaDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.TurmaRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public override void Create(TurmaEntity entity)
        {
            base.Create(entity);
        }

        public override void Delete(TurmaEntity entity)
        {
            #region Não é permitido excluir turma que contenha 1 ou mais aluno

            var numAlunos = unitOfWork.AlunoRepository
                .Count(f => f.TurmaId == entity.Id);

            if (numAlunos > 0)
                throw new ExclusaoNaoPermitidaException(numAlunos);

            #endregion

            base.Delete(entity);
        }
    }
}
