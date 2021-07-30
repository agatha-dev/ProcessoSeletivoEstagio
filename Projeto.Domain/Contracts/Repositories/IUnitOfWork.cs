using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories

        ITurmaRepository TurmaRepository { get; }
        IAlunoRepository AlunoRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        #endregion

        #region Transactions

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion
    }
}
