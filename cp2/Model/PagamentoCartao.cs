using System.Linq;

public class PagamentoCartao : Pagamento
{
    public string NumeroCartao { get; set; }

    private const int MIN = 13;
    private const int MAX = 19;

    public override string ProcessarPagamento()
    {
        string numero = Limpar(NumeroCartao);

        if (!numero.All(char.IsDigit))
            return "Erro: o número do cartão deve conter apenas números.";

        if (numero.Length < MIN || numero.Length > MAX)
            return $"Erro: o cartão deve ter entre {MIN} e {MAX} dígitos. Informado: {numero.Length}.";

        return $"Processando pagamento de R$ {Valor:F2} via Cartão (Número: {numero}) na data {DataAtual()}.";
    }

    private string Limpar(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "";
        return new string(input.Where(char.IsDigit).ToArray());
    }
}