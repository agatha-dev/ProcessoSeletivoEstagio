using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class AlunoRepository
        : BaseRepository<AlunoEntity>, IAlunoRepository
    {
        //atributo
        private readonly SqlContext sqlContext;

        //construtor para inicialização do atributo
        public AlunoRepository(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public override List<AlunoEntity> GetAll()
        {
            return sqlContext
                .Aluno
                .Include(f => f.Turma) //LEFT JOIN
                .ToList();
        }

        public override List<AlunoEntity> GetAll(Func<AlunoEntity, bool> where)
        {
            return sqlContext
                .Aluno
                .Include(f => f.Turma) //LEFT JOIN
                .Where(where)
                .ToList();
        }

        public override AlunoEntity GetById(Guid id)
        {
            return sqlContext
                .Aluno
                .Include(f => f.Turma) //LEFT JOIN
                .FirstOrDefault(f => f.Id == id);
        }

        public override AlunoEntity Get(Func<AlunoEntity, bool> where)
        {
            return sqlContext
                .Aluno
                .Include(f => f.Turma) //LEFT JOIN
                .FirstOrDefault(where);
        }
    }
}
