using System;

namespace ClienteService.Domain.Interfaces;

public interface IEventPublisher : IDisposable
{
    Task PublishAsync<T>(T @event) where T : class;
}
