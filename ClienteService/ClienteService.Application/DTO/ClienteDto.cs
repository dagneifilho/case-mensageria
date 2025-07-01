using System;
using ClienteService.Domain.Enums;

namespace ClienteService.Application.DTO;

public class ClienteDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string StatusCartao { get; set; }

    public string StatusProposta { get; set; }
}
