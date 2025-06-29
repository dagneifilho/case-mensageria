using System;
using System.Data;

namespace CartaoCredtoService.Domain.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
