using System;

namespace IdentityProviderCore.Entities
{
    public class AccessToken : BaseEntity
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Exhausted { get; set; }
        public bool LongLived { get; set; }
        public DateTime TokenExpireAt { get; set; }
        public DateTime RefreshTokenExpireAt { get; set; }
        public string Nonce { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
