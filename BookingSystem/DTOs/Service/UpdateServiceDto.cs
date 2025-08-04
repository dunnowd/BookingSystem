namespace BookingSystem.DTOs.Service
{
    public class UpdateServiceDto
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Cost { get; set; }
    }
}
