using System;
using ClienteService.Domain.Enums;

namespace ClienteService.Domain.Entities;

public class ClienteDetalhado
{
    public Guid ClienteId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public Status StatusCartao { get; set; }
    public Status StatusProposta { get; set; }
    public Guid CartaoId { get; set; }
    public string NumeroCartao { get; set; }
    public Guid AprovacaoId { get; set; }
}
