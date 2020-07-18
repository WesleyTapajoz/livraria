using System;
using System.Collections.Generic;
using System.Linq;
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

        //// GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var usuarios = await _repo.GetAllAsync<User>(true);

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
                var livro = await _repo.GetAllAsync<Livro>(true);
                var results = _mapper.Map<LivroDto[]>(livro);
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
        [HttpGet("GetInstituicoesEnsino")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInstituicoesEnsino()
        {
            try
            {
                var instituicoesEnsino = await _repo.GetAllAsync<InstituicaoEnsino>(true);
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
                var emprestimo = await _repo.GetAllAsync<Emprestimo>(true);
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
        public async Task<IActionResult> AdicionarEmprestimo(EmprestimoDto model)
        {
            try
            {
                var evento = _mapper.Map<Emprestimo>(model);

                _repo.Add(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.EmprestimoId}", _mapper.Map<Emprestimo>(evento));
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
        public async Task<IActionResult> AdicionarInstituicao([FromBody]InstituicaoEnsinoDto model)
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
        public async Task<IActionResult> AdicionarReserva([FromBody]ReservaDto model)
        {
            try
            {
                var reserva = _mapper.Map<Reserva>(model);

                _repo.Add(reserva);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{model.ReservaId}", _mapper.Map<Reserva>(reserva));
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
        public async Task<IActionResult> InstituicaoDisable([FromBody]InstituicaoEnsinoDto instituicaoEnsinoDtoDto)
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

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
