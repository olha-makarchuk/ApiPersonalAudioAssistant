using MediatR;
using ApiPersonalAudioAssistant.Application.Interfaces;
using ApiPersonalAudioAssistant.Domain.Entities;

namespace ApiPersonalAudioAssistant.Application.PlatformFeatures.Commands.SettingsCommands
{
    public class UpdateBalanceCommand: IRequest<Unit>
    {
        public required string UserId { get; set; }
        public decimal RechargeAmountInput { get; set; }
        public string MaskedCardNumber { get; set; }
        public string DescriptionPayment { get; set; }
    }

    public class UpdateBalanceCommandHandler : IRequestHandler<UpdateBalanceCommand, Unit>
    {
        private readonly IAppSettingsRepository _settingsRepository;
        private readonly IPaymentHistoryRepository _paymentHistoryRepository;

        public UpdateBalanceCommandHandler(IAppSettingsRepository settingsRepository, IPaymentHistoryRepository paymentHistoryRepository)
        {
            _settingsRepository = settingsRepository;
            _paymentHistoryRepository = paymentHistoryRepository;
        }

        public async Task<Unit> Handle(UpdateBalanceCommand request, CancellationToken cancellationToken = default)
        {
            var settings = await _settingsRepository.GetSettingsByUserIdAsync(request.UserId, cancellationToken);

            if (settings == null)
            {
                throw new Exception("Settings not found.");
            }

            settings.Balance += request.RechargeAmountInput;

            var paymentHistory = new PaymentHistory
            {
                UserId = request.UserId,
                Amount = request.RechargeAmountInput,
                DateTimePayment = DateTime.UtcNow,
                MaskedCardNumber = request.MaskedCardNumber,
                Description = request.DescriptionPayment
            };

            await _paymentHistoryRepository.AddPaymentHistoryAsync(paymentHistory, cancellationToken);
            await _settingsRepository.UpdateSettingsAsync(settings, cancellationToken);

            return Unit.Value;
        }
    }
}
