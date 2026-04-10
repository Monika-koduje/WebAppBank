using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Company.Data.Data
{
    // Klasa reprezentująca typ karty
    public class CardType
    {
        // Klucz podstawowy dla tabeli CardType
        [Key]
        public int IdCardType { get; set; }

        // Nazwa typu karty, np. kredytowa, debetowa
        [Required(ErrorMessage = "Card type name is required")]
        [MaxLength(50, ErrorMessage = "Card type name should have only 50 characters.")]
        [Display(Name = "Card Type")]
        public string? Name { get; set; }

        // Opcjonalny opis typu karty
        [MaxLength(200, ErrorMessage = "Card type description should have only 200 characters.")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        // Kolekcja kart, które mają ten typ
        public virtual ICollection<Card>? Cards { get; set; } = new List<Card>();
    }
}
