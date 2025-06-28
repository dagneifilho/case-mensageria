using System;
using System.Data;

namespace ClienteService.Domain.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
