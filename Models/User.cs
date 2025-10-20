namespace IpsAusentismos.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Email { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public int? ManagerId { get; set; }
        public User? Manager { get; set; }

        public int? AreaId { get; set; }
        public Area? Area { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
