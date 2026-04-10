using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Data
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name should have only 50 characters.")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name should have only 50 characters.")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [MaxLength(100, ErrorMessage = "Position should have only 100 characters.")]
        [Display(Name = "Position")]
        public string? Position { get; set; }

        [Required(ErrorMessage = "Hire date is required")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [MaxLength(15, ErrorMessage = "Phone number should have only 15 characters.")]
        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [ForeignKey("Branch")]
        public int IdBranch { get; set; }

        public virtual Branch? Branch { get; set; }
    }
}
