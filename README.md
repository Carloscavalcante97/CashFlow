# 📊 CashFlow

Bem-vindo ao **CashFlow**, uma poderosa aplicação desenvolvida em **C#** para otimizar o **controle financeiro pessoal e empresarial**. Com o CashFlow, você pode **registrar receitas e despesas**, **calcular seu saldo disponível** e **gerar relatórios financeiros detalhados**. Tudo isso garantindo a **integridade dos dados** por meio de validações robustas. 🚀

---

## ✨ Funcionalidades

- ✅ **Registro de Transações**: Adicione **receitas e despesas** de forma simples e rápida.
- ✅ **Cálculo de Saldo**: Obtenha automaticamente o **saldo atualizado** com base nas transações registradas.
- ✅ **Relatórios Financeiros**: Gere **relatórios detalhados** para análise financeira e tomada de decisões informadas.
- ✅ **Exportação para Excel**: Exporte suas despesas registradas em **formato Excel (.xlsx)** para auditorias e planejamento estratégico.
- ✅ **Validações de Dados**: Mantenha a **segurança e consistência** dos seus registros financeiros com **validações robustas**.

---

## 🛠️ Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [✅ .NET SDK 6.0 ou superior](https://dotnet.microsoft.com/download)
- [✅ SQL Server ou outro banco de dados compatível](https://www.microsoft.com/sql-server)

---

## ⚙️ Configuração do Ambiente

Para iniciar o projeto, siga os passos abaixo:

```sh
# Clone o repositório
git clone https://github.com/Carloscavalcante97/CashFlow.git
cd CashFlow

# Restaure as dependências do projeto
dotnet restore

# Atualize o banco de dados
dotnet ef database update
```

---

## 🚀 Execução da Aplicação

Para rodar o **CashFlow**, utilize o comando:

```sh
dotnet run --project src/CashFlow
```

A aplicação estará disponível em **`https://localhost:5001`** (ou conforme configurado no projeto). 🌐

---

## 📊 Exportação de Despesas para Excel

O **CashFlow** permite a exportação das despesas para um **arquivo Excel (.xlsx)**, tornando mais fácil a organização e análise dos dados.

### 📤 Como Exportar:

1. Acesse a seção **Relatórios** dentro da aplicação.
2. Escolha a opção **Exportação** e selecione o formato **Excel (.xlsx)**.
3. O sistema irá gerar um **arquivo Excel** contendo todas as despesas registradas. 🎯

---

## ✅ Testes

Para garantir a **qualidade e integridade** do código, execute os testes do projeto com:

```sh
dotnet test
```

---

## 📜 Licença

Este projeto está licenciado sob a **Licença MIT**. Para mais detalhes, consulte o arquivo `LICENSE` no repositório.

---

## 📬 Contato

Para dúvidas, sugestões ou suporte, entre em contato:

- **GitHub**: [Carloscavalcante97](https://github.com/Carloscavalcante97)
- **Email**: [carlos.developer@icloud.com](mailto:carlos.developer@icloud.com)

---

💰 **Gerencie suas finanças com mais eficiência usando o CashFlow!** 🚀
