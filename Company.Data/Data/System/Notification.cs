using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data.Data
{
    public class Notification
    {
        [Key]
        public int IdNotification { get; set; }

        [Required(ErrorMessage = "Notification title is required")]
        [MaxLength(100, ErrorMessage = "Notification title should have only 100 characters.")]
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [Display(Name = "Message")]
        public string? Message { get; set; }

        [Display(Name = "Notification Date")]
        public DateTime NotificationDate { get; set; } = DateTime.Now;

        // Relacja do Klientów
        [Required]
        [ForeignKey("Client")]
        public int IdClient { get; set; }

        public virtual Client? Client { get; set; }
    }
}

