using AppAlunos_BackEnd.Models;
using AppAlunos_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppAlunos_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);

            } catch
            {
                return BadRequest("Request inválido.");
            }
        }
        [HttpGet("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunoByNome([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunoByNome(nome);
                if (alunos != null)
                {
                    return Ok(alunos);
                }
                return NotFound($"Não existe alunos com o nome {nome}");
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }
        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno == null)
                {
                    NotFound($"Não existe aluno com id={id}");
                }
                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAluno([FromBody] Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new {id = aluno.Id}, aluno);

            } catch
            {
                return BadRequest("Request inválido.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAluno(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.Id == id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Aluno com id={id} foi atualizado com sucesso");
                } else
                {
                    return BadRequest("Dados inconsistentes.");
                }
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno de id={id} foi excluido com sucesso");
                } else
                {
                    return NotFound($"Aluno de id={id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }
    }
}
