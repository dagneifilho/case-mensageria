using System;

namespace CreditoService.Domain.Entities;

public class PropostaCredito
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public bool Aprovado { get; set; }
    public DateTime DataAprovacao { get; set; }

}
