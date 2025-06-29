using System;

namespace CartaoCreditoService.Domain.Entities;

public class CartaoCredito
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public string NumeroCartao { get; set; }
    public DateTime Validade { get; set; }

    public void GerarNumeroCartao()
    {
        Random random = new();
        int[] digits = new int[16];

        digits[0] = 4;
        for (int i = 1; i < 15; i++)
            digits[i] = random.Next(0, 10);

        
        int soma = 0;
        for (int i = 0; i < 15; i++)
        {
            int num = digits[14 - i];
            if (i % 2 == 0)
            {
                num *= 2;
                if (num > 9) num -= 9;
            }
            soma += num;
        }

        digits[15] = (10 - (soma % 10)) % 10;

        NumeroCartao =  string.Join("", digits);
    }
}
