using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Data
{
    public class ClientBankProduct
    {
        [Key]
        public int IdClientProduct { get; set; }

        [ForeignKey("Client")]
        public int IdClient { get; set; }

        public virtual Client? Client { get; set; }

        [ForeignKey("BankProduct")]
        public int IdProduct { get; set; }

        public virtual BankProduct? BankProduct { get; set; }

        [Display(Name = "Acquired Date")]
        public DateTime AcquiredDate { get; set; } = DateTime.Now;
    }
}

