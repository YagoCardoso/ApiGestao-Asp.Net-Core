//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using ApiGestao.Data;
//using ApiGestao.Models;

//namespace ApiGestao.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AgendamentoController : ControllerBase
//    {

//        #region Mestre
//        private readonly AppDbContext _context;
//        public readonly IRepository _repo;

//        public AgendamentoController(AppDbContext context, IRepository repo)
//        {
//             _repo = repo;
//            _context = context;
//        }

//        // GET: api/Agendamento
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
//        {
//            //return await _context.Agendamentos.ToListAsync();
//            return await _context.Agendamentos.Where(a => a.DT_FIM < DateTime.Now).ToListAsync();

//            //var ocupadas = await _context.Agendamentos.Where(a => a.DT_FIM > DateTime.Now).Select(b => b.Sala.NOME).ToListAsync();
//            //var disponiveis = await _context.Agendamentos.Where(a => a.DT_FIM < DateTime.Now).Select(b => b.Sala.NOME).ToListAsync();

//        }

//        // GET: api/Agendamento/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
//        {
//            var agendamento = await _context.Agendamentos.FindAsync(id);



//            if (agendamento == null)
//            {
//                return NotFound();
//            }

//            return agendamento;
//        }

//        // PUT: api/Agendamento/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAgendamento(int id, Agendamento agendamento)
//        {
//            if (id != agendamento.IDAGENDAMENTO)
//            {
//                return BadRequest();
//            }

//            _context.Entry(agendamento).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AgendamentoExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Agendamento
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<Agendamento>> PostAgendamento(Agendamento agendamento)
//        {

//            var ids_ocupadas = await _context.Agendamentos.Where(a => a.DT_FIM > DateTime.Now).Select(b => b.Sala.NOME).ToListAsync();
//            var ids_disponiveis = await _context.Agendamentos.Where(a => a.DT_FIM < DateTime.Now).Select(b => b.Sala.NOME).ToListAsync();
//            //var salas_ocupadas = new List<string>();
//            //var salas_disponiveis = new List<string>();
//            var getagendamento = await _context.Agendamentos.FindAsync(agendamento.IDAGENDAMENTO);

//            if (agendamento.DT_INICIO < getagendamento.DT_FIM)
//            {
//                return BadRequest();
//            }

//            _context.Agendamentos.Add(agendamento);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetAgendamento", new { id = agendamento.IDAGENDAMENTO }, agendamento);
//        }

//        // DELETE: api/Agendamento/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Agendamento>> DeleteAgendamento(int id)
//        {
//            var agendamento = await _context.Agendamentos.FindAsync(id);
//            if (agendamento == null)
//            {
//                return NotFound();
//            }

//            _context.Agendamentos.Remove(agendamento);
//            await _context.SaveChangesAsync();

//            return agendamento;
//        }

//        private bool AgendamentoExists(int id)
//        {
//            return _context.Agendamentos.Any(e => e.IDAGENDAMENTO == id);
//        }
//        #endregion

//        #region Validações

//        private async Task<bool> ValidarAgendamentoAsync(Agendamento agendamento)
//        {
//            var reserbaNoBanco = await _context.Agendamentos.FindAsync(agendamento.IDSALA);
//            var getsala = await _context.Sala.FindAsync(agendamento.IDSALA);

//            //if (agendamento.DT_FIM > agendamento.DT_INICIO)
//            //{
//            //    //nao pode fazer uma reserva pra uma data menor doque  a hora inicial
//            //}

//            if (agendamento.DT_INICIO < reserbaNoBanco.DT_FIM)
//            {
//                return false;
//            }



//            return true;
//        }
//        #endregion


//    }
//}
