using GestioneFilm.Database;
using GestioneFilm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioneFilm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FilmController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("All")]
        public async Task<ActionResult<List<Film>>> GetAllFilms()
        {
            var films = await _context.Film.ToListAsync();
            return Ok(films);
        }
        [HttpGet("Ricerca:{id}")]
        public async Task<ActionResult<Film>> GetFilm(int id)
        {
            var film = await _context.Film.FindAsync(id);
            if(film is null)
            {
                return NotFound("Film non trovato");
            }
            return Ok(film);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Film>> AddFilm(AddFilm newFilm)
        {
            var film = new Film()
            {
                Titolo = newFilm.Titolo,
                Regista = newFilm.Regista,
                Anno = newFilm.Anno,
                Genere = newFilm.Genere
            };
            _context.Film.Add(film);
            await _context.SaveChangesAsync();
            var films = await _context.Film.ToListAsync();
            return Ok(films);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Film>> UpdateFilm(Film updateFilm)
        {
            var update = await _context.Film.FindAsync(updateFilm.Id);
            if (update is null)
            {
                return NotFound("Film non trovato");
            }
                update.Titolo = updateFilm.Titolo;
                update.Regista = updateFilm.Regista;
                update.Anno = updateFilm.Anno;
                update.Genere = updateFilm.Genere;
            await _context.SaveChangesAsync();
            var films = await _context.Film.ToListAsync();
            return Ok(films);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<Film>> DeleteFilm(int id)
        {
            var film = await _context.Film.FindAsync(id);
            if (film is null)
            {
                return NotFound("Film nooooo trovato");
            }
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
            return Ok(await _context.Film.ToListAsync());
        }

    }
}
