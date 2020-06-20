using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDeOrdenes.Models
{
    public class Suplidores
    {
        [Key]
        public int suplidorId { get; set; }
        public string nombre { get; set; }

        public Suplidores()
        {
            suplidorId = 0;
            nombre = string.Empty;
        }
    }
}
