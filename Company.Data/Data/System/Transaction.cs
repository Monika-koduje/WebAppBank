using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Data
{
    public class Transaction
    {
        [Key]
        public int IdTransaction { get; set; }

        [ForeignKey("Account")]
        public int IdAccount { get; set; }

        public virtual Account? Account { get; set; }

        [Required(ErrorMessage = "Transaction amount is required")]
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [MaxLength(255, ErrorMessage = "Description should have only 255 characters.")]
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}

