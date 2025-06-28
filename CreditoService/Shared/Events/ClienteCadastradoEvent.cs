using System;

namespace Shared.Events;

public class ClienteCadastradoEvent
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}
