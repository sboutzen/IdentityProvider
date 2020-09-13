using System;

namespace IdentityProviderCore.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public Guid EntityId { get; set; }

        public Guid UserId { get; set; }
    }
}
