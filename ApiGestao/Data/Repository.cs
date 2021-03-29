using ApiGestao.Data;
using ApiGestao.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestao.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        #region Sala
        /// <summary>
        /// Metodo assincrono para trazer todos os registro de sala
        /// </summary>
        /// <returns></returns>
        public async Task<PageList<Sala>> GetAllSalasAsync(PageParams pageParams)
        {
            IQueryable<Sala> query = _context.Sala;

            query = query.AsNoTracking().OrderBy(a => a.IDSALA);

            // return await query.ToListAsync();
            return await PageList<Sala>.CreateAsnc(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public async Task<Sala[]> GetAllSalasAsyncNotPageList()
        {
            IQueryable<Sala> query = _context.Sala;
            query = query.AsNoTracking().OrderBy(a => a.IDSALA);

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// Metodo assincrono para trazer a sala pesquisando através do nome 
        /// </summary>
        /// <param name="salaNome"></param>
        /// <returns></returns>
        public async Task<Sala[]> GetAllSalasByNomeAsync(string salaNome)
        {
            IQueryable<Sala> query = _context.Sala;

            query = query.Where(a => a.NOME.Contains(salaNome));

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Metodo assincrono para trazer o registro de sala através do Id
        /// </summary>
        /// <param name="idSala"></param>
        /// <returns></returns>
        public async Task<Sala> GetSalaByIdAsync(int idSala)
        {
            IQueryable<Sala> query = _context.Sala;

            query = query.AsNoTracking()
           .OrderBy(a => a.IDSALA)
             .Where(a => a.IDSALA == idSala);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Sala> GetNomeSalaByIdAsync(int idSala)
        {
            IQueryable<Sala> query = _context.Sala;

            query = (IQueryable<Sala>)query.AsNoTracking()
           .OrderBy(a => a.IDSALA)
             .Where(a => a.IDSALA == idSala).Select(b => b.NOME);

            return await query.FirstOrDefaultAsync();
        }

        #endregion

        #region Agendamento
        /// <summary>
        /// Metodo assincrono para trazer todos os registro de Agendamento
        /// </summary>
        /// <param name="includeSala"></param>
        /// <returns></returns>
        public async Task<Agendamento[]> GetAllAgendamentosAsync(bool includeSala)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            if (includeSala)
            {
                query = query.Include(a => a.Sala)
                       .ThenInclude(b => b.NOME);
            }

            query = query.AsNoTracking().OrderBy(a => a.IDAGENDAMENTO);

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Metodos assincrono para trazer o agendamento  pesquisando através do Id da sala
        /// </summary>
        /// <param name="idSala"></param>
        /// <param name="includeSala"></param>
        /// <returns></returns>
        public async Task<Agendamento[]> GetAllAgendamentosByIdSalaAsync(int idSala, bool includeSala = false)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            //if (includeSala)
            //{
            //    query = query.Include(a => a.Sala)
            //    .ThenInclude(a => a.NOME);
            //}

            query = query.Where(a => a.IDSALA == idSala)
                .OrderBy(b => b.IDSALA);

            //query = query.AsNoTracking()
            //.OrderBy(a => a.IDAGENDAMENTO)
            //.Where(agen => agen.IDAGENDAMENTO.Any(ad => ad. = disciplinaId));

            return await query.ToArrayAsync();
        }
        /// <summary>
        /// Metodos assincrono para trazer o registro de Agendamento através do Id
        /// </summary>
        /// <param name="idAgendamento"></param>
        /// <param name="includeSala"></param>
        /// <returns></returns>
        public async Task<Agendamento> GetAgendamentoByIdAsync(int idAgendamento, bool includeSala = false)
        {
            IQueryable<Agendamento> query = _context.Agendamentos;
            if (includeSala)
            {
                query = query.Include(a => a.Sala)
                       .ThenInclude(b => b.NOME);
            }

                  query = query.AsNoTracking()
                 .OrderBy(a => a.IDAGENDAMENTO)
                   .Where(a => a.IDAGENDAMENTO == idAgendamento);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Agendamento[]> GetAllSalasDisponiveisAsync()
        {
            //IQueryable<Agendamento> query = _context.Agendamentos;
            //query = query.AsNoTracking().OrderBy(a => a.IDAGENDAMENTO).Where(a => a.DT_FIM < DateTime.Now);
            //query = query.Include(pe => pe.Sala)
            //               .ThenInclude(ad => ad.NOME);

            //return await query.ToArrayAsync();

            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.AsNoTracking()
                         .OrderBy(c => c.IDAGENDAMENTO).Where(a => a.DT_FIM < DateTime.Now);

            return await query.ToArrayAsync();
        }
        public async Task<Agendamento[]> GetAllSalasIndisponiveisAsync()
        {
            //IQueryable<Agendamento> query = _context.Agendamentos;
            //query = query.AsNoTracking().OrderBy(a => a.IDAGENDAMENTO).Where(a => a.DT_FIM > DateTime.Now);
            //query = query.Include(pe => pe.Sala)
            //                .ThenInclude(ad => ad.NOME);

            //return await query.ToArrayAsync();
            IQueryable<Agendamento> query = _context.Agendamentos;
            query = query.AsNoTracking()
                         .OrderBy(c => c.IDAGENDAMENTO).Where(a => a.DT_FIM > DateTime.Now);

            return await query.ToArrayAsync();
        }

   
        #endregion



    }
}
