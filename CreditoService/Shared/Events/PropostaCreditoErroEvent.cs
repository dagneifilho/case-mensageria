using System;

namespace Shared.Events;

public class PropostaCreditoErroEvent
{
    public Guid ClienteId { get; set; }
    public string ErrorMessage { get; set; }
}
