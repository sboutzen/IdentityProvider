using System;

namespace IdentityProviderCore.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public Guid EntityId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
