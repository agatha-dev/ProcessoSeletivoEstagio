using Projeto01.Application.Contracts;
using Projeto01.Application.DTOs;
using Projeto01.Application.Models.Turma;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Projeto01.Application.Services
{
    public class TurmaApplicationService : ITurmaApplicationService
    {
        private readonly ITurmaDomainService turmaDomainService;

        public TurmaApplicationService(ITurmaDomainService turmaDomainService)
        {
            this.turmaDomainService = turmaDomainService;
        }

        public TurmaApplicationService()
        {
        }

        public TurmaDTO Create(TurmaCadastroModel model)
        {
            var turmaEntity = new TurmaEntity
            {
                DataInicio = DateTime.Parse(model.DataInicio),
                NomeProfessor = model.NomeProfessor,
                NomeCurso = model.NomeCurso
            };

            turmaDomainService.Create(turmaEntity);

            return new TurmaDTO
            {
                Id = turmaEntity.Id,
                NomeCurso = turmaEntity.NomeCurso,
                NomeProfessor = turmaEntity.NomeProfessor,
                DataInicio = turmaEntity.DataInicio
            };
        }

        public TurmaDTO Update(TurmaEdicaoModel model)
        {
            var turmaEntity = turmaDomainService.GetById(model.Id);

            if (turmaEntity == null)
                throw new Exception("Turma não encontrada.");

            turmaEntity.NomeCurso = model.NomeCurso;
            turmaEntity.NomeProfessor = model.NomeProfessor;
            turmaEntity.DataInicio = DateTime.Parse(model.DataInicio);

            turmaDomainService.Update(turmaEntity);

            return new TurmaDTO
            {
                Id = turmaEntity.Id,
                NomeProfessor = turmaEntity.NomeProfessor,
                NomeCurso = turmaEntity.NomeCurso,
                DataInicio = turmaEntity.DataInicio
            };
        }

        public TurmaDTO Delete(Guid id)
        {
            var turmaEntity = turmaDomainService.GetById(id);

            if (turmaEntity == null)
                throw new Exception(" Turma não encontrada.");

            turmaDomainService.Delete(turmaEntity);

            return new TurmaDTO
            {
                Id = turmaEntity.Id,
                NomeCurso = turmaEntity.NomeCurso,
                NomeProfessor = turmaEntity.NomeProfessor,
                DataInicio = turmaEntity.DataInicio
            };
        }

        public List<TurmaDTO> GetAll()
        {
            var result = new List<TurmaDTO>();

            foreach (var item in turmaDomainService.GetAll())
            {
                result.Add(new TurmaDTO
                {
                    Id = item.Id,
                    NomeProfessor = item.NomeProfessor,
                    NomeCurso = item.NomeCurso,
                    DataInicio = item.DataInicio
                });
            }

            return result;
        }

        public TurmaDTO GetById(Guid id)
        {
            var turmaEntity = turmaDomainService.GetById(id);

            if (turmaEntity == null)
                return null;

            return new TurmaDTO
            {
                Id = turmaEntity.Id,
                NomeCurso = turmaEntity.NomeCurso,
                NomeProfessor = turmaEntity.NomeProfessor,
                DataInicio = turmaEntity.DataInicio
            };
        }

        public void Dispose()
        {
            turmaDomainService.Dispose();
        }

    }
}
