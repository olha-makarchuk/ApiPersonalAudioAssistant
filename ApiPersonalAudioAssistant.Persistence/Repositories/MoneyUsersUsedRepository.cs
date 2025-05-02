using ApiPersonalAudioAssistant.Application.Interfaces;
using ApiPersonalAudioAssistant.Domain.Entities;
using ApiPersonalAudioAssistant.Persistence.Context;

namespace ApiPersonalAudioAssistant.Persistence.Repositories
{
    public class MoneyUsersUsedRepository : IMoneyUsersUsedRepository
    {
        private readonly CosmosDbContext _context;
        public MoneyUsersUsedRepository(CosmosDbContext context)
        {
            _context = context;
        }

        public Task AddMoneyUsersUsedAsync(MoneyUsersUsed moneyUsersUsed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<MoneyUsersUsed>> GetMoneyUsersUsedByRangeSubUsersIdAsync(List<string> subUsersId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<MoneyUsersUsed> GetMoneyUsersUsedbySubUserIdAsync(string subUserId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMoneyUsersUsedAsync(MoneyUsersUsed moneyUsersUsed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
