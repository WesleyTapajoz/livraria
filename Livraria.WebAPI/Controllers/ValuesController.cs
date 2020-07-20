using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Livraria.Domain;
using Livraria.Domain.Entity;
using Livraria.Repository;
using Livraria.WebAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public ValuesController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _repo.GetAllAsync<User>();

                var results = _mapper.Map<UsuarioDto[]>(usuarios);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        /// <summary>
        /// Livros
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLivros")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLivros()
        {
            try
            {
                var livro = await _repo.GetAllAsync<Livro>();
                var results = _mapper.Map<LivroDto[]>(livro);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        /// <summary>
        /// InstituicoesEnsino
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetInstituicoesEnsino")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInstituicoesEnsino()
        {
            try
            {
                var instituicoesEnsino = await _repo.GetAllAsync<InstituicaoEnsino>();
                var results = _mapper.Map<InstituicaoEnsinoDto[]>(instituicoesEnsino);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }


        /// <summary>
        /// Emprestimos
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmprestimo")]
        public async Task<IActionResult> GetEmprestimo()
        {
            try
            {
                var emprestimo = await _repo.GetAllAsync<Emprestimo>();
                var results = _mapper.Map<Emprestimo[]>(emprestimo);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }


        // POST api/<controller>
        [HttpPost("AdicionarEmprestimo")]
        [AllowAnonymous]
        public async Task<IActionResult> AdicionarEmprestimo([FromBody] EmprestimoDto model)
        {
            try
            {
                var retorno = await _repo.GetAllEmprestimoByLivroIdAsync(model.LivroId);

                if (retorno.Count() > 0)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"Livro Indisponível.");
                }

                var emprestimo = _mapper.Map<Emprestimo>(model);

                _repo.Add(emprestimo);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        // POST api/<controller>
        [HttpPost("AdicionarInstituicao")]
        [AllowAnonymous]
        public async Task<IActionResult> AdicionarInstituicao([FromBody] InstituicaoEnsinoDto model)
        {
            try
            {
                model.Ativo = true;
                var evento = _mapper.Map<InstituicaoEnsino>(model);

                _repo.Add(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        // POST api/<controller>
        [HttpPost("AdicionarReserva")]
        [AllowAnonymous]
        public async Task<IActionResult> AdicionarReserva([FromBody] ReservaDto model)
        {
            try
            {
                var reserva = _mapper.Map<Reserva>(model);

                _repo.Add(reserva);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("InstituicaoDisable")]
        [AllowAnonymous]
        public async Task<IActionResult> InstituicaoDisable([FromBody] InstituicaoEnsinoDto instituicaoEnsinoDtoDto)
        {
            try
            {
                var model = await _repo.GetById<InstituicaoEnsino>(instituicaoEnsinoDtoDto.InstituicaoEnsinoId);
                model.Ativo = false;
                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();

        }

        [HttpPost("AdicionarLivro")]
        [AllowAnonymous]
        public async Task<IActionResult> AdicionarLivro([FromBody] LivroDto model)
        {
            try
            {
                var livro = _mapper.Map<Livro>(model);

                _repo.Add(livro);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("LivroDisable")]
        [AllowAnonymous]
        public async Task<IActionResult> LivroDisable([FromBody] LivroDto livroDto)
        {
            try
            {
                var model = await _repo.GetById<Livro>(livroDto.LivroId);
                model.Ativo = false;
                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();

        }


        [HttpPost("upload")]
        [AllowAnonymous]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "img");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    using var stream = new FileStream(fullPath, FileMode.Create);
                    file.CopyTo(stream);
                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

        }

        [HttpPut("AlterarLivro")]
        [AllowAnonymous]
        public async Task<IActionResult> AlterarLivro([FromBody] LivroDto livroDto)
        {
            try
            {
                var model = await _repo.GetById<Livro>(livroDto.LivroId);

                _mapper.Map(livroDto, model);
                 model.Ativo = true;

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();

        }
    }
}
