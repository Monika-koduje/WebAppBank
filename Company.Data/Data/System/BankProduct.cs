using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Data
{
    public class BankProduct
    {
        [Key]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(100, ErrorMessage = "Product name should have only 100 characters.")]
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Product type is required")]
        [MaxLength(50, ErrorMessage = "Product type should have only 50 characters.")]
        [Display(Name = "Product Type")]
        public string? ProductType { get; set; }

        [Required(ErrorMessage = "Interest rate is required")]
        [Display(Name = "Interest Rate")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRate { get; set; }

        // Relacja wiele-do-wiele z Klientami
        public virtual ICollection<ClientBankProduct>? ClientBankProducts { get; set; }
    }
}
