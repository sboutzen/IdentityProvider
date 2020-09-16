using IdentityProviderCore.Entities;
using IdentityProviderCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityProviderInfrastructure.Contexts
{
    public class IdentityProviderDbSeeder
    {
        public IdentityProviderDbContext _context { get; set; }
        public IIdentityProviderEntityBuilder _entityBuilder { get; set; }
        public IdentityProviderDbSeeder(IdentityProviderDbContext context, IIdentityProviderEntityBuilder entityBuilder)
        {
            _context = context;
            _entityBuilder = entityBuilder;
        }

        public async Task SeedAsync(ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryCount = retry.Value;
            try
            {
                await seedClients();
                await seedUsers();
            }
            catch (Exception e)
            {
                bool shouldRetry = (retryCount < 10);
                if (shouldRetry)
                {
                    retryCount++;
                    ILogger<IdentityProviderDbSeeder> log = loggerFactory.CreateLogger<IdentityProviderDbSeeder>();
                    log.LogError(e.Message);
                    await SeedAsync(loggerFactory, retryCount);
                }
                throw;
            }
        }

        private async Task seedClients()
        {
            bool hasNoClients = !await _context.Clients.AnyAsync();
            if (hasNoClients)
            {
                IEnumerable<Client> clients = await _entityBuilder.BuildClients();
                await _context.Clients.AddRangeAsync(clients);
                await _context.SaveChangesAsync();
            }
        }

        private async Task seedUsers()
        {
            bool hasNoUsers = !await _context.Users.AnyAsync();
            if (hasNoUsers)
            {
                IEnumerable<User> users = await _entityBuilder.BuildUsers();
                await _context.Users.AddRangeAsync(users);
                await _context.SaveChangesAsync();
            }
        }
    }
}
