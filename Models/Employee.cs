namespace IpsAusentismos.Models
{
    public class Employee : BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Document { get; set; } = string.Empty;
        public DateTime? HireDate { get; set; }
        public string Status { get; set; } = "Activo";
    }
}
