using System;

namespace ClienteService.Application.DTO;

public class ClienteDetalhadoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string StatusCartao { get; set; }

    public string StatusProposta { get; set; }
    public Guid CartaoId { get; set; }
    public string NumeroCartao { get; set; }
    public Guid AprovacaoId { get; set; }
}
