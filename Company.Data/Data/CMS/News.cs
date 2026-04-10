using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Data.CMS
{
    public class News
    {
        [Key]
        public int IdNews { get; set; }

        [Required(ErrorMessage = "Title link is required")]
        [MaxLength(30, ErrorMessage = "Title link should have only 30 characters.")]
        [Display(Name = "Title link")]
        public string LinkTitle { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(30, ErrorMessage = "Title should have only 30 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }

        [Display(Name = "Order of display")]
        [Required(ErrorMessage = "Order of display is required")]
        public int DisplayOrder { get; set; }
    }
}

