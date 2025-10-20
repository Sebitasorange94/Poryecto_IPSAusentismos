namespace IpsAusentismos.Models
{
    public class Vacation : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationStatus Status { get; set; } = VacationStatus.Solicitada;
        public int? ApprovedByUserId { get; set; }
        public User? ApprovedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
