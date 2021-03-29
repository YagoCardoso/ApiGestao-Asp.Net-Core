using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestao.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Sala
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDSALA { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NOME { get; set; }
    }
}
