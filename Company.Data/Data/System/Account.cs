using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Data
{
    public class Account
    {
        [Key]
        public int IdAccount { get; set; }

        [Required(ErrorMessage = "Account number is required")]
        [MaxLength(20, ErrorMessage = "Account number should have only 20 characters.")]
        [Display(Name = "Account Number")]
        public string? AccountNumber { get; set; }

        [Required(ErrorMessage = "Balance is required")]
        [Display(Name = "Balance")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; } = 0.00M;

        [ForeignKey("Client")]
        public int IdClient { get; set; }

        public virtual Client? Client { get; set; }

        // Relacja z Transakcjami
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}

