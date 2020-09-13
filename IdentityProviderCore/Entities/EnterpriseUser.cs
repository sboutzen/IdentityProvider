using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityProviderCore.Entities
{
    public class EnterpriseUser : BaseUser
    {
        public string OrganizationName { get; set; }
    }
}
