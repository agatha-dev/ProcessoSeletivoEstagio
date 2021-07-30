using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Contracts;
using Projeto01.Application.Models.Empresas;

namespace Projeto01.Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaApplicationService turmaApplicationService;

        public TurmaController(ITurmaApplicationService turmaApplicationService)
        {
            this.turmaApplicationService = turmaApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post(TurmaCadastroModel model)
        {
            try
            {
                var turmaDTO = turmaApplicationService.Create(model);

                return StatusCode(201, new
                {
                    Message = "Turma cadastrada com sucesso.",
                    Turma = turmaDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(TurmaEdicaoModel model)
        {
            try
            {
                var turmaDTO = turmaApplicationService.Update(model);

                return StatusCode(200, new
                {
                    Message = "turma atualizada com sucesso.",
                    Turma = turmaDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var turmaDTO = turmaApplicationService.Delete(id);

                return StatusCode(200, new
                {
                    Message = "turma excluída com sucesso.",
                    Turma = turmaDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var result = turmaApplicationService.GetAll();

                //se o resultado é vazio
                if (result == null || result.Count == 0)
                    return StatusCode(204);

                return StatusCode(200, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var turmaDTO = turmaApplicationService.GetById(id);

                //se o resultado é vazio
                if (turmaDTO == null)
                    return StatusCode(204);

                return StatusCode(200, turmaDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                }); ;
            }
        }
    }
}
