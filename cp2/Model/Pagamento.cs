using System;

public abstract class Pagamento
{
    public decimal Valor { get; set; }

    public abstract string ProcessarPagamento();

    protected string DataAtual()
    {
        return DateTime.Now.ToString("dd/MM/yyyy");
    }
}