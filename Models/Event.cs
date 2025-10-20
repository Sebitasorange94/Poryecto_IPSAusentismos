namespace IpsAusentismos.Models
{
    public class Event : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public string? Description { get; set; }
        public int CreatedByUserId { get; set; }
        public User? CreatedBy { get; set; }
    }
}
