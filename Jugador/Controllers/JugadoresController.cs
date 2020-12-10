using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jugador.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jugador.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase {

        private readonly Contexto contexto;

        public JugadoresController(Contexto _contexto) {
            contexto = _contexto;
        }

        [HttpGet]
        public async Task<List<Jugador>> GetJugadores() {
            return (await contexto.Jugadores.ToListAsync())
                .OrderByDescending(j => j.Puntuacion)
                .ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Jugador>> Guardar(Jugador jugador) {
            await contexto.Jugadores.AddAsync(jugador);
            var paso = await contexto.SaveChangesAsync() > 0;
            if (paso) {
                return Ok(jugador);
            } else {
                return BadRequest(); 
            }
        }

    }
}
