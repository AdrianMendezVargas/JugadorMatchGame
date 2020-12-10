using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jugador {
    public class Jugador {
        [Key]
        public int JugadorId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Puntuacion { get; set; }
    }
}
