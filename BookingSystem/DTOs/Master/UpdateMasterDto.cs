using System.ComponentModel.DataAnnotations;

namespace BookingSystem.DTOs.Master
{
    public class UpdateMasterDto
    {
        [Required]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "The name length must be between 3 and 35 characters.")]
        public string Name { get; set; } = string.Empty;
    }
}
