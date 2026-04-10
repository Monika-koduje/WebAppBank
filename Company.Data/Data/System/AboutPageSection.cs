using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Data
{
        public class AboutPageSection
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(100, ErrorMessage = "Section name cannot exceed 100 characters.")]
            public string? SectionName { get; set; }

            [Required]
            public string? Content { get; set; }

            [Url]
            public string? ImageUrl { get; set; }

            [MaxLength(50)]
            public string? IconClass { get; set; }

            [Required]
            public int Order { get; set; }

            [Required]
            public bool IsActive { get; set; }
        }
    }
