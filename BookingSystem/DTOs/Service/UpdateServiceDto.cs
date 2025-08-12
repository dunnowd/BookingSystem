using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTOs.Service
{
    public class UpdateServiceDto
    {
        [Required]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "The name length must be between 3 and 35 characters.")]
        public string Name { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        [Range(1, 10000)]
        public decimal Cost { get; set; }
    }
}
