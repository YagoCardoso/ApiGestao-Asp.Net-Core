using ApiGestao.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestao.Models
{
    /// <summary>
    /// Classe Interface d Repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Metodo Add para usar nos controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Add<T>(T entity) where T : class;
        /// <summary>
        /// Metodo Add para usar nos controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Update<T>(T entity) where T : class;
        /// <summary>
        /// Metodo Add para usar nos controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Delete<T>(T entity) where T : class;
        /// <summary>
        /// Metodo Add para usar nos controller
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();

        #region Salas
        /// <summary>
        /// Metodo assincrono para trazer todos os registro de sala
        /// </summary>
        /// <returns></returns>
        Task<List<Sala>> GetAllSalasAsync(PageParams pageParams, int offset = 0, int limit = 1);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Sala[]> GetAllSalasAsyncNotPageList();
        /// <summary>
        /// Metodo assincrono para trazer a sala pesquisando através do nome 
        /// </summary>
        /// <param name="salaNome"></param>
        /// <returns></returns>
        Task<Sala[]> GetAllSalasByNomeAsync(string salaNome);
        /// <summary>
        /// Metodo assincrono para trazer o registro de sala através do Id
        /// </summary>
        /// <param name="idSala"></param>
        /// <returns></returns>
        Task<Sala> GetSalaByIdAsync(int idSala);
        Task<Sala> GetNomeSalaByIdAsync(int idSala);
        #endregion

        #region Agendamentos
        /// <summary>
        /// Metodo assincrono para trazer todos os registro de Agendamento
        /// </summary>
        /// <param name="includeSala"></param>
        /// <returns></returns>
        Task<Agendamento[]> GetAllAgendamentosAsync(bool includeSala);
        /// <summary>
        /// Metodos assincrono para trazer o agendamento  pesquisando através do Id da sala
        /// </summary>
        /// <param name="idSala"></param>
        /// <param name="includeSala"></param>
        /// <returns></returns>
        Task<Agendamento[]> GetAllAgendamentosByIdSalaAsync(int idSala, bool includeSala = false);
        /// <summary>
        /// Metodos assincrono para trazer o registro de Agendamento através do Id
        /// </summary>
        /// <param name="idAgendamento"></param>
        /// <param name="includeSala"></param>
        /// <returns></returns>
        Task<Agendamento> GetAgendamentoByIdAsync(int idAgendamento, bool includeSala = false);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<dynamic>> GetAllSalasDisponiveisAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<dynamic>> GetAllSalasIndisponiveisAsync();
        #endregion

    }
}
