using System.Globalization;

class Program
{
    static void Main()
    {
        while (true)
        {
            Menu.ExibirMenu();
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ProcessarPagamentoCartao();
                    break;
                case "2":
                    ProcessarPagamentoBoleto();
                    break;
                case "3":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void ProcessarPagamentoCartao()
    {
        decimal valor = LerValorPagamento();
        Console.Write("Informe o número do cartão: ");
        string numeroCartao = Console.ReadLine();

        var pagamento = new PagamentoCartao
        {
            Valor = valor,
            NumeroCartao = numeroCartao
        };

        Console.WriteLine(pagamento.ProcessarPagamento());
    }

    static void ProcessarPagamentoBoleto()
    {
        decimal valor = LerValorPagamento();
        Console.Write("Informe o código de barras: ");
        string codigoBarras = Console.ReadLine();

        var pagamento = new PagamentoBoleto
        {
            Valor = valor,
            CodigoBarras = codigoBarras
        };

        Console.WriteLine(pagamento.ProcessarPagamento());
    }

    static decimal LerValorPagamento()
    {
        decimal valor;
        while (true)
        {
            Console.Write("Informe o valor do pagamento: ");
            string input = Console.ReadLine();
            if (decimal.TryParse(input, NumberStyles.Currency, CultureInfo.CurrentCulture, out valor))
                break;
            Console.WriteLine("Valor inválido. Tente novamente.");
        }
        return valor;
    }
}
