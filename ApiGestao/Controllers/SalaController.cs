using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGestao.Data;
using ApiGestao.Models;
using ApiGestao.Helpers;
using X.PagedList;
using System.Text.Json;

namespace ApiGestao.Controllers
{

    /// <summary>
    /// Controller SalaController
    /// </summary>
    /// 
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        #region Mestre
        public readonly IRepository _repo;

        /// <summary>
        /// Repositorio
        /// </summary>
        /// <param name="repo"></param>
        public SalaController(IRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Método responsável por retorna todas as salas Cadastradas
        /// </summary>
        /// <returns></returns>
        // GET: api/Sala
        [HttpGet]
        // public async Task<IActionResult> GetSala([FromQuery]PageParams pageParams)
         public async Task<IActionResult> GetSala(int offset = 0, int limit = 1)
        {
            //  var result = await _repo.GetAllSalasAsync(pageParams);

            try
            {
                var result = await _repo.GetAllSalasAsyncNotPageList();
                result.Skip(offset)
                       .Take(limit)
                       .ToList(); 

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }


        /// <summary>
        /// Método responsável por retorna uma unica sala Cadastrada, através do id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Sala/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSala(int id)
        {
          
            try
            {
                var result = await _repo.GetSalaByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        /// <summary>
        ///  Método responsável por Incluir uma nova sala
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/Sala
        [HttpPost]
        public async Task<ActionResult<Sala>> PostSala(Sala model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Sala não encontrada");
        }


        /// <summary>
        ///  Método responsável por alterar informações da sala, informando todos os campos que compõem o registro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT: api/Sala/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSala(int id, Sala model)
        {
            try
            {
                var sala = await _repo.GetSalaByIdAsync(id);
                if (sala != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangesAsync())
                        return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Sala não encontrada");
        }


        /// <summary>
        ///  Método responsável por alterar informações da sala, informando somente oque deseja alterar no registro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // Patch: api/Sala/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchSala(int id, Sala model)
        {
            try
            {
                var sala = await _repo.GetSalaByIdAsync(id);
                if (sala != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangesAsync())
                        return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Sala não encontrada");

        }


        /// <summary>
        ///  Método responsável por deletar o registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Sala/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sala>> DeleteSala(int id)
        {
            try
            {
                var sala = await _repo.GetSalaByIdAsync(id);
                if (sala != null)
                {
                    _repo.Delete(sala);

                    if (await _repo.SaveChangesAsync())
                        return Ok(sala);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Deletado!");
         
        }

        #endregion

        /// <summary>
        /// Retornar salas disponiveis
        /// </summary>
        /// <returns></returns>
        // GET: api/Sala/
        [HttpGet("GetSalasDisponiveis")]
        public async Task<IActionResult> GetSalasDisponiveis()
        {
            var salasDisponiveis = await _repo.GetAllSalasDisponiveisAsync();
            return Ok(salasDisponiveis);
        }

        /// <summary>
        /// Retorna salas indisponiveis
        /// </summary>
        /// <returns></returns>
        // GET: api/Sala/

        [HttpGet("GetSalasIndisponiveis")]
        public async Task<IActionResult> GetSalasIndisponiveis()
        {
            var salasIndisponiveis = await _repo.GetAllSalasIndisponiveisAsync();
            return Ok(salasIndisponiveis);

        }



    }
}
