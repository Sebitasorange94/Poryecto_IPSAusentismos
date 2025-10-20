using IpsAusentismos.Models;

namespace IpsAusentismos.Infrastructure
{
    public static class Session
    {
        public static User? CurrentUser { get; private set; }
        public static void SetUser(User u) => CurrentUser = u;
        public static void Clear() => CurrentUser = null;
        public static bool IsInRole(string roleName) => CurrentUser?.Role?.Name == roleName;
    }
}
