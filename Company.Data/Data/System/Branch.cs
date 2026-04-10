using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Data
{
    public class Branch
    {
        [Key]
        public int IdBranch { get; set; }

        [Required(ErrorMessage = "Branch name is required")]
        [MaxLength(100, ErrorMessage = "Branch name should have only 100 characters.")]
        [Display(Name = "Branch Name")]
        public string? BranchName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(200, ErrorMessage = "Address should have only 200 characters.")]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(100, ErrorMessage = "City should have only 100 characters.")]
        [Display(Name = "City")]
        public string? City { get; set; }

        [MaxLength(10, ErrorMessage = "Postal code should have only 10 characters.")]
        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set; }

        [MaxLength(15, ErrorMessage = "Phone number should have only 15 characters.")]
        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        // Relacja z Pracownikami (Employees)
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}

