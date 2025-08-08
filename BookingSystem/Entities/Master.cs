namespace BookingSystem.Entities
{
    public class Master
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Service> Services { get; } = new();
    }
}
