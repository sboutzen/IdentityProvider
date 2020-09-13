using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IdentityProviderCore.Entities
{
    public abstract class BaseUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UserId { get; set; }
    }
}
