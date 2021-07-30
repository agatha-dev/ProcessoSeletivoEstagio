using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class TurmaRepository
        : BaseRepository<TurmaEntity>, ITurmaRepository
    {
        //atributo
        private readonly SqlContext sqlContext;

        //construtor para inicialização do atributo (injeção de dependência)
        public TurmaRepository(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
