using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Data.CMS
{
    // Klasa reprezentująca stronę w systemie CMS
    public class Page
    {
        // Klucz podstawowy dla tabeli Page
        [Key]
        public int IdPage { get; set; }

        // Pole 'LinkTitle' - wymagane, max 30 znaków
        [Required(ErrorMessage = "Title link is required")]
        [MaxLength(30, ErrorMessage = "Title link should have only 30 characters.")]
        [Display(Name = "Title link")]
        public string LinkTitle { get; set; }

        // Pole 'Title' - wymagane, max 30 znaków
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "Title should have only 30 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        // Pole 'Content' - tekst o zmiennym rozmiarze
        [Display(Name = "Content")]
        [Column(TypeName = "nvarchar(MAX)")] // Określenie typu kolumny na MAX dla dużych tekstów
        public string Content { get; set; }

        // Pole 'DisplayOrder' - liczba całkowita określająca kolejność wyświetlania
        [Display(Name = "Order of display")]
        [Required(ErrorMessage = "Order of display is required")]
        public int DisplayOrder { get; set; }
    }
}
