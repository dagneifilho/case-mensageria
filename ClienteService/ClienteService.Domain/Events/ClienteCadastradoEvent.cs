using System;
using ClienteService.Domain.Interfaces;

namespace ClienteService.Domain.Events;

public class ClienteCadastradoEvent : IClienteCadastradoEvent
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}
