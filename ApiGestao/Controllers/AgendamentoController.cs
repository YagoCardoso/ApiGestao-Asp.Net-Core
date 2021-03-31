using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGestao.Data;
using ApiGestao.Models;

namespace ApiGestao.Controllers
{

    /// <summary>
    /// ControllerAgendamento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {

        #region Mestre
        private readonly AppDbContext _context;
        public readonly IRepository _repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repo"></param>
        public AgendamentoController(AppDbContext context, IRepository repo)
        {
             _repo = repo;
        }


        /// <summary>
        ///  Método responsável por retorna todas as reservas agendadas
        /// </summary>
        /// <returns></returns>
        // GET: api/Agendamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
        {
            try
            {
                var result = await _repo.GetAllAgendamentosAsync(false);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Método responsável por retorna uma unica reserva Cadastrada, através do id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Agendamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
        {
            try
            {
                var result = await _repo.GetAgendamentoByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: api/Agendamento
        [HttpPost]
        public async Task<ActionResult<Agendamento>> PostAgendamento(Agendamento model)
        {
            //verificando disponbilidade da sala
            var reservas = await _repo.GetAllAgendamentosByIdSalaAsync(model.IDSALA);

            foreach (var item in reservas)
            {
                if (model.DT_INICIO < item.DT_FIM)
                {
                    return BadRequest("Sala não disponivel");
                }
            }
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // PUT: api/Agendamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(int id, Agendamento model)
        {
            if (id != model.IDAGENDAMENTO)
                try
                {
                    var agendamento = await _repo.GetAgendamentoByIdAsync(id);
                    if (agendamento != null)
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

            return BadRequest("Não encontrado");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Agendamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Agendamento>> DeleteAgendamento(int id)
        {
            try
            {
                var agendamento = await _repo.GetAgendamentoByIdAsync(id);
                if (agendamento != null)
                {
                    _repo.Delete(agendamento);

                    if (await _repo.SaveChangesAsync())
                        return Ok(agendamento);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest($"Não Deletado!");
        }

        #endregion

    }
}
