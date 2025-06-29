using System;

namespace CreditoService.Domain.Interfaces;

public interface IEventPublisher : IDisposable
{
    Task PublishAsync<T>(T @event) where T : class;
}

