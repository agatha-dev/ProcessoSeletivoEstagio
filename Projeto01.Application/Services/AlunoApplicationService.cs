using Projeto01.Application.Contracts;
using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Funcionarios;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using Projeto01.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Application.Services
{
    public class AlunoApplicationService : IAlunoApplicationService
    {
        //atributos
        private readonly IAlunoDomainService alunoDomainService;
        private readonly ITurmaDomainService turmaDomainService;

        public AlunoApplicationService(IAlunoDomainService alunoDomainService, 
            ITurmaDomainService turmaDomainService)
        {
            this.alunoDomainService = alunoDomainService;
            this.turmaDomainService = turmaDomainService;
        }

        public AlunoDTO Create(AlunoCadastroModel model)
        {
            var alunoEntity = new AlunoEntity
            {
                Id = Guid.NewGuid(),
                Nome = model.Nome,
                Cpf = model.Cpf,
                DataNascimento = DateTime.Parse(model.DataNascimento),
                Sexo = (SexoEnum)char.Parse(model.Sexo),
                TurmaId = Guid.Parse(model.TurmaId)
            };

            alunoDomainService.Create(alunoEntity);

            var turma = turmaDomainService.GetById(alunoEntity.TurmaId);
            return new AlunoDTO
            {
                Id = alunoEntity.Id,
                Nome = alunoEntity.Nome,
                Cpf = alunoEntity.Cpf,
                DataNascimento = alunoEntity.DataNascimento,
                Sexo = alunoEntity.Sexo,

                Turma = new TurmaEntity
                {
                    Id = turma.Id,
                    NomeCurso = turma.NomeCurso,
                    NomeProfessor = turma.NomeProfessor,
                    DataInicio = DateTime.Parse(turma.DataInicio.ToString())
                }
            };
        }

        public AlunoDTO Update(AlunoEdicaoModel model)
        {
            var alunoEntity = alunoDomainService.GetById(model.Id);

            if (alunoEntity == null)
                throw new Exception("Funcionário não encontrado.");

            alunoEntity.Nome = model.Nome;
            alunoEntity.DataNascimento = DateTime.Parse(model.DataNascimento);
            alunoEntity.Sexo = (SexoEnum)char.Parse(model.Sexo);

            alunoDomainService.Update(alunoEntity);

            var turma = turmaDomainService.GetById(alunoEntity.TurmaId);
            return new AlunoDTO
            {
                Id = alunoEntity.Id,
                Nome = alunoEntity.Nome,
                Cpf = alunoEntity.Cpf,
                DataNascimento = alunoEntity.DataNascimento,
                Sexo = alunoEntity.Sexo,
                Turma = new TurmaEntity
                {
                    Id = turma.Id,
                    NomeCurso = turma.NomeCurso,
                    NomeProfessor = turma.NomeProfessor,
                    DataInicio = turma.DataInicio
                }
            };
        }

        public AlunoDTO Delete(Guid id)
        {
            var alunoEntity = alunoDomainService.GetById(id);

            if (alunoEntity == null)
                throw new Exception("Funcionário não encontrado.");

            alunoDomainService.Delete(alunoEntity);

            var turma = turmaDomainService.GetById(alunoEntity.TurmaId);
            return new AlunoDTO
            {
                Id = alunoEntity.Id,
                Nome = alunoEntity.Nome,
                Cpf = alunoEntity.Cpf,
                DataNascimento = alunoEntity.DataNascimento,
                Sexo = alunoEntity.Sexo,
                Turma = new TurmaEntity
                {
                    Id = turma.Id,
                    NomeCurso = turma.NomeCurso,
                    NomeProfessor = turma.NomeProfessor,
                    DataInicio = turma.DataInicio
                }
            };
        }

        public List<AlunoDTO> GetAll()
        {
            var result = new List<AlunoDTO>();

            foreach (var item in alunoDomainService.GetAll())
            {
                result.Add(new AlunoDTO
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    DataNascimento = item.DataNascimento,
                    Sexo = item.Sexo,
                    Turma = new TurmaEntity
                    {
                        Id = item.Turma.Id,
                        NomeProfessor = item.Turma.NomeProfessor,
                        NomeCurso = item.Turma.NomeCurso,
                        DataInicio = item.Turma.DataInicio
                    }
                });
            }

            return result;
        }

        public AlunoDTO GetById(Guid id)
        {
            var alunoEntity = alunoDomainService.GetById(id);

            if (alunoEntity == null)
                return null;

            return new AlunoDTO
            {
                Id = alunoEntity.Id,
                Nome = alunoEntity.Nome,
                Cpf = alunoEntity.Cpf,
                DataNascimento = alunoEntity.DataNascimento,
                Sexo = alunoEntity.Sexo,
                Turma = new TurmaEntity
                {
                    Id = alunoEntity.Turma.Id,
                    NomeCurso = alunoEntity.Turma.NomeCurso,
                    NomeProfessor = alunoEntity.Turma.NomeProfessor,
                    DataInicio = alunoEntity.Turma.DataInicio
                }
            };
        }

        public void Dispose()
        {
            alunoDomainService.Dispose();
            turmaDomainService.Dispose();
        }
    }
}
