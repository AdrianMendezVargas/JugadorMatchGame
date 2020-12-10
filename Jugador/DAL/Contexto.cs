using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugador.DAL {
    public class Contexto : DbContext {

        public DbSet<Jugador> Jugadores { get; set; }

        public Contexto(DbContextOptions options): base(options) {

        }
    }
}
