using IdentityProviderCommon.Enums;
using System.Collections.Generic;

namespace IdentityProviderCore.Entities
{
    public class Client : BaseEntity
    {
        public Organization Organization { get; set; }
        public string? PhoneNumber { get; set; }
        public List<User> Users { get; set; }
    }
}
