using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestao.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Agendamento
    {
        
        /// <summary>
        /// 
        /// </summary>
        public int IDAGENDAMENTO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TITULO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT_INICIO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT_FIM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Sala Sala { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IDSALA { get; set; }
    }
}
