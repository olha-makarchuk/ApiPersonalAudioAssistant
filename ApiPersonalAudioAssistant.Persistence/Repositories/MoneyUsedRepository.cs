using ApiPersonalAudioAssistant.Application.Interfaces;
using ApiPersonalAudioAssistant.Domain.Entities;
using ApiPersonalAudioAssistant.Persistence.Context;

namespace ApiPersonalAudioAssistant.Persistence.Repositories
{
    public class MoneyUsedRepository: IMoneyUsedRepository
    {
        private readonly CosmosDbContext _context;
        public MoneyUsedRepository(CosmosDbContext context)
        {
            _context = context;
        }

        public Task AddMoneyUsedAsync(MoneyUsed moneyUsed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task GetMoneyUsedbyMainIdAndAsync(string moneyUsedId, DateTime dateTime, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<MoneyUsed>> GetMoneyUsedByMainUserIdAsync(string mainUserId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMoneyUsedAsync(MoneyUsed moneyUsed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<MoneyUsed> IMoneyUsedRepository.GetMoneyUsedbyMainIdAndDateAsync(string moneyUsedId, DateTime dateTime, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
