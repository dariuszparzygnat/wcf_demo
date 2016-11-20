using System.ComponentModel.DataAnnotations;

namespace LibraryClient.Models
{
    public class AddBookViewModel
    {
        [Required(ErrorMessage = "Musisz wprowadzić tytuł")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzić autora")]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Musisz wprowadzić rok publikacji")]
        [Display(Name = "Rok publikacji")]
        public int? YearOfPublication { get; set; }
    }
}