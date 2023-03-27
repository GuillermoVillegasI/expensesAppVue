using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vueJsBack.Models
{
    public class Gasto
    {

        public int id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string name { get; set; }
        [Required]
        public double value { get; set; }
    }
}
