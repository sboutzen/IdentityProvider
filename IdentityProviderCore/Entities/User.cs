using System.Collections.Generic;

namespace IdentityProviderCore.Entities
{
    public class User : BaseEntity
    {
        public bool IsAdmin { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Email Email { get; set; }
        public List<AccessToken> AccessTokens { get; set; }
    }
}
