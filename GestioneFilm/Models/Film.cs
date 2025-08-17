using System.ComponentModel.DataAnnotations;

namespace GestioneFilm.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string? Titolo { get; set; }
        public string? Regista { get; set; }
        public int Anno { get; set; }
        public string? Genere { get; set; }
    }
}
