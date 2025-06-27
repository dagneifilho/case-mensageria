using System;

namespace ClienteService.Domain.Interfaces;

public interface IClienteCadastradoEvent : IEvent
{
    Guid Id { get; }
    string Nome { get; }
    string Email { get; }
}
