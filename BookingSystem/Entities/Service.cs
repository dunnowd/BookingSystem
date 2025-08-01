namespace BookingSystem.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public decimal Cost { get; set; }

        public List<Master> Masters { get; } = new();
        public List<MasterService> MasterServices { get; } = new();
    }
}
