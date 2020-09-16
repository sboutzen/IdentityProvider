using IdentityProviderCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityProviderCore.Interfaces
{
    public interface IIdentityProviderEntityBuilder
    {
        public Task<IEnumerable<Client>> BuildClients();
        public Task<IEnumerable<Email>> BuildEmails();
        public Task<IEnumerable<User>> BuildUsers();
        public Task<IEnumerable<AccessToken>> BuildAccessTokens();
    }
}
