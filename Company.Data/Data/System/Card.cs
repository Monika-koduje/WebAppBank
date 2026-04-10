using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Data
{
    // Klasa reprezentująca kartę w systemie bankowym
    public class Card
    {
        // Klucz podstawowy dla tabeli Card
        [Key]
        public int IdCard { get; set; }

        // Pole 'CardNumber' - numer karty, wymagany, unikalny
        [Required(ErrorMessage = "Card number is required")]
        [MaxLength(16, ErrorMessage = "Card number should have only 16 characters.")]
        [MinLength(16, ErrorMessage = "Card number should have 16 characters.")]
        [Display(Name = "Card Number")]
        public string? CardNumber { get; set; }

        // Pole 'ExpiryDate' - data ważności karty, wymagane
        [Required(ErrorMessage = "Expiry date is required")]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        // Klucz obcy do tabeli 'CardType' (relacja wiele do jednego)
        [ForeignKey("CardType")]
        public int CardTypeId { get; set; }

        // Nawigacja do obiektu 'CardType' (relacja wiele do jednego)
        public virtual CardType? CardType { get; set; }

        // Pole 'CardHolder' - imię właściciela karty, wymagane
        [Required(ErrorMessage = "Card holder name is required")]
        [MaxLength(100, ErrorMessage = "Card holder name should have only 100 characters.")]
        [Display(Name = "Card Holder")]
        public string? CardHolder { get; set; }

        // Pole 'CVV' - kod CVV karty, wymagany
        [Required(ErrorMessage = "CVV is required")]
        [MaxLength(3, ErrorMessage = "CVV should have only 3 characters.")]
        [MinLength(3, ErrorMessage = "CVV should have 3 characters.")]
        [Display(Name = "CVV")]
        public string? CVV { get; set; }

    }
}
