using BookingSystem.DTOs.Service;
using BookingSystem.Entities;

namespace BookingSystem.DTOs.Master
{
    public class MasterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ServiceDto> Services { get; } = new();
    }
}
