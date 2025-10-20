using IpsAusentismos.Models;
using Microsoft.AspNetCore.Identity;

namespace IpsAusentismos.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<User> _hasher = new();
        public string Hash(User? u, string plain) => _hasher.HashPassword(u ?? new User(), plain);
        public bool Verify(User u, string plain) =>
            _hasher.VerifyHashedPassword(u, u.PasswordHash, plain) != PasswordVerificationResult.Failed;
    }
}
