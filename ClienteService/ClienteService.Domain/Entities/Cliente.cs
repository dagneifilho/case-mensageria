using System;
using ClienteService.Domain.Enums;

namespace ClienteService.Domain.Entities;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public Status StatusCartao { get; set; }
    public Status StatusProposta { get; set; }
}
