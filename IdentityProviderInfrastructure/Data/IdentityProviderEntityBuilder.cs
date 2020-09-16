using IdentityProviderCommon.Enums;
using IdentityProviderCore.Entities;
using IdentityProviderCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityProviderInfrastructure.Data
{
    public class IdentityProviderEntityBuilder : IIdentityProviderEntityBuilder
    {
        public async Task<IEnumerable<Client>> BuildClients()
        {
            return await Task.FromResult(new List<Client>()
            {
                new Client { Id = 1, EntityId = Guid.NewGuid(), Organization = Organization.Maersk },
                new Client { Id = 2, EntityId = Guid.NewGuid(), Organization = Organization.Dfds, PhoneNumber = "some phone number 2" },
                new Client { Id = 3, EntityId = Guid.NewGuid(), Organization = Organization.Ultranav, PhoneNumber = "some phone number 3" }
            });
        }
        public async Task<IEnumerable<User>> BuildUsers()
        {
            return await Task.FromResult(new List<User>()
            {
                new User { Id = 1, EntityId = Guid.NewGuid(), IsAdmin = true, PasswordHash = "hash1", PasswordSalt = "salt1", ClientId = 1 },
                new User { Id = 2, EntityId = Guid.NewGuid(), IsAdmin = true, PasswordHash = "hash2", PasswordSalt = "salt2", ClientId = 2 },
                new User { Id = 3, EntityId = Guid.NewGuid(), IsAdmin = false, PasswordHash = "hash3", PasswordSalt = "salt3", ClientId = 3 }
            });
        }

        public async Task<IEnumerable<Email>> BuildEmails()
        {
            return await Task.FromResult(new List<Email>() { });
        }

        public async Task<IEnumerable<AccessToken>> BuildAccessTokens()
        {
            return await Task.FromResult(new List<AccessToken>() { });
        }
    }
}
