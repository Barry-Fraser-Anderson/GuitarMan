using System.ComponentModel.DataAnnotations;

namespace GuitarMan.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Link { get; set; }
    }
}
