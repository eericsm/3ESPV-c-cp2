- Eric Segawa Montagner - RM558224
- Joao Victor Oliveira dos Santos - RM557948
- Matheus Alcântara Estevão - RM558193
- Nicolle Pellegrino Jelinski - RM558610
- Pedro Pereira dos Santos - RM552047

# Sistema de Processamento de Pagamentos (Console - C#)

## Descrição
Aplicação de console desenvolvida em C# que simula um sistema simples de processamento de pagamentos. O sistema permite ao usuário escolher entre pagamento com **Cartão** ou **Boleto**, inserir os dados necessários, validar as informações e exibir um resumo da operação.

---

## Objetivo
Aplicar conceitos fundamentais de:
- Programação Orientada a Objetos (POO)
- Validação de dados
- Manipulação de entrada no console
- Organização de código em camadas

---

## Funcionalidades

### Menu principal
- Exibe opções ao usuário:
  - `1 - Cartão`
  - `2 - Boleto`
  - `3 - Sair`
- Mantém execução contínua até o usuário optar por sair

### Processamento de pagamentos
- Solicita valor do pagamento
- Valida que o valor seja **maior que zero**
- Solicita dados específicos:
  - Cartão → número do cartão
  - Boleto → código de barras
- Exibe mensagem final com os dados da operação

---

## Validações implementadas

### Valor do pagamento
- Aceita diferentes formatos numéricos (`150,50` ou `150.50`)
- Não permite:
  - Valores zero
  - Valores negativos

---

### Cartão
- Aceita apenas números
- Limite: **13 a 19 dígitos**
- Entrada controlada:
  - Usuário não consegue digitar mais que o limite
  - Permite uso de backspace

---

### Boleto
- Aceita apenas números
- Código de barras deve ter:
  - **Exatamente 44 dígitos**
- Entrada também limitada no console

---

## Conceitos aplicados

### Programação Orientada a Objetos
- Classe abstrata `Pagamento`
- Classes derivadas:
  - `PagamentoCartao`
  - `PagamentoBoleto`
- Uso de **polimorfismo** com `ProcessarPagamento()`

---

### Separação de responsabilidades
- `Program.cs` → controle do fluxo da aplicação
- `Menu.cs` → exibição do menu
- `Model/` → regras de negócio

---

### Validação e segurança de entrada
- Sanitização de dados (remoção de caracteres inválidos)
- Bloqueio de entrada inválida em tempo real (`Console.ReadKey`)
- Evita erros comuns de entrada do usuário
