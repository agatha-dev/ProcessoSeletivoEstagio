using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Contracts;
using Projeto01.Application.Models.Aluno;

namespace Projeto01.Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoApplicationService alunoApplicationService;

        public AlunoController(IAlunoApplicationService alunoApplicationService)
        {
            this.alunoApplicationService = alunoApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Post(AlunoCadastroModel model)
        {
            try
            {
                var alunoDTO = alunoApplicationService.Create(model);

                return StatusCode(201, new
                {
                    Message = "Aluno cadastrado com sucesso.",
                    Aluno = alunoDTO
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Put(AlunoEdicaoModel model)
        {
            try
            {
                var alunoDTO = alunoApplicationService.Update(model);

                return StatusCode(200, new
                {
                    Message = "Aluno atualizado com sucesso.",
                    Aluno = alunoDTO
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
                var alunoDTO = alunoApplicationService.Delete(id);

                return StatusCode(200, new
                {
                    Message = "Aluno excluído com sucesso.",
                    Aluno = alunoDTO
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
                var result = alunoApplicationService.GetAll();

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
                var alunoDTO = alunoApplicationService.GetById(id);

                if (alunoDTO == null)
                    return StatusCode(204);

                return StatusCode(200, alunoDTO);
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