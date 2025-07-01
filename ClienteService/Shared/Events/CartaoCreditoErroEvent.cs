using System;

namespace Shared.Events;

public class CartaoCreditoErroEvent
{
    public Guid ClienteId { get; set; }
    public string ErrorMessage { get; set; }

}
