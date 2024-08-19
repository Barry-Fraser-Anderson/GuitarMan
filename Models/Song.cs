using System.ComponentModel.DataAnnotations;

namespace GuitarMan.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string Artist { get; set; } = String.Empty;
        [Required]
        public string Title { get; set; } = String.Empty;
        
        public string? Description { get; set; }
        [Required]
        public string Link { get; set; } = String.Empty;
    }
}
