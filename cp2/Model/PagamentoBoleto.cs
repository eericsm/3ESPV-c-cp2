using System.Drawing;

public class PagamentoBoleto : Pagamento
{
    public string CodigoBarras { get; set; }

    public override string ProcessarPagamento()
    {
        return $"Processando pagamento de R$ {Valor:F2} via Boleto (Cod Barra: {CodigoBarras}) na data {DataAtual()}.";
    }
}