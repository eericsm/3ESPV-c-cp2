using System.Linq;

public class PagamentoBoleto : Pagamento
{
    public string CodigoBarras { get; set; }

    private const int TAMANHO = 44;

    public override string ProcessarPagamento()
    {
        string codigo = Limpar(CodigoBarras);

        if (!codigo.All(char.IsDigit))
            return "Erro: o código de barras deve conter apenas números.";

        if (codigo.Length != TAMANHO)
            return $"Erro: o código de barras deve ter exatamente {TAMANHO} dígitos. Informado: {codigo.Length}.";

        return $"Processando pagamento de R$ {Valor:F2} via Boleto (Cod Barra: {codigo}) na data {DataAtual()}.";
    }

    private string Limpar(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "";
        return new string(input.Where(char.IsDigit).ToArray());
    }
}