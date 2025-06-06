﻿using ApiPersonalAudioAssistant.Domain.Entities;

namespace ApiPersonalAudioAssistant.Application.Interfaces
{
    public interface IAutoPaymentRepository
    {
        Task<AutoPayments> GetAutoPaymentByIdAsync(string userId, CancellationToken cancellationToken);
        Task<AutoPayments> GetAutoPaymentByUserIdAsync(string userId, CancellationToken cancellationToken);
        Task UpdateAutoPaymentAsync(AutoPayments autoPayment, CancellationToken cancellationToken);
        Task AddAutoPaymentAsync(AutoPayments autoPayment, CancellationToken cancellationToken);
    }
}
