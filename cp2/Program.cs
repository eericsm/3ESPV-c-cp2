using System;
using System.Globalization;
using System.Text;

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

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void ProcessarPagamentoCartao()
    {
        decimal valor = LerValorPagamento();

        Console.Write("Informe o número do cartão (13 a 19 dígitos): ");
        string numeroCartao = LerEntradaComLimite(19);

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

        Console.Write("Informe o código de barras (44 dígitos): ");
        string codigoBarras = LerEntradaComLimite(44);

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
            Console.Write("Informe o valor do pagamento (maior que zero): ");
            string input = Console.ReadLine();

            if (!decimal.TryParse(input, NumberStyles.Any, CultureInfo.CurrentCulture, out valor))
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
                continue;
            }

            if (valor <= 0)
            {
                Console.WriteLine("O valor deve ser maior que zero.");
                continue;
            }

            return valor;
        }
    }

    static string LerEntradaComLimite(int max)
    {
        var buffer = new StringBuilder();

        while (true)
        {
            var tecla = Console.ReadKey(intercept: true);

            if (tecla.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                break;
            }

            if (tecla.Key == ConsoleKey.Backspace && buffer.Length > 0)
            {
                buffer.Remove(buffer.Length - 1, 1);
                Console.Write("\b \b");
                continue;
            }

            if (buffer.Length < max && char.IsDigit(tecla.KeyChar))
            {
                buffer.Append(tecla.KeyChar);
                Console.Write(tecla.KeyChar);
            }
        }

        return buffer.ToString();
    }
}