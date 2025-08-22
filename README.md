# Teste.API

API REST para gerenciamento de estoque de produtos, desenvolvida em .NET 8.

## ✨ Funcionalidades

- **CRUD de Produtos**: Crie, consulte, atualize e remova produtos do estoque.
- **Controle de Estoque**: Atualize a quantidade e realize vendas de produtos.
- **Regras de Negócio**:
  - Não permite adicionar produtos com o mesmo ID.
  - Não permite remover ou atualizar produtos inexistentes.
  - Não permite vender mais do que o estoque disponível.

## 📁 Estrutura do Projeto

├── Controllers/ │ └── ProdutoController.cs ├── Models/ │ └── Produto.cs ├── Services/ │ ├── ProdutoService.cs │ └── Interfaces/ │ └── IProdutoService.cs ├── Tests/ │ └── TestsAPI.cs ├── Program.cs ├── appsettings.json ├── README.md ├── Teste.API.csproj

🛣️ Endpoints Principais
GET /produto — Lista todos os produtos
GET /produto/{id} — Detalha um produto
POST /produto — Adiciona um novo produto
PUT /produto/{id} — Atualiza um produto existente
DELETE /produto/{id} — Remove um produto
PUT /produto/{id}/quantity — Atualiza a quantidade em estoque
POST /produto/{id}/sell — Realiza uma venda (diminui o estoque)

🧩 Exemplo de Modelo
🧪 Testes
Os testes unitários estão em Tests/TestsAPI.cs e cobrem cenários positivos e negativos das regras de negócio.

Feito com 💙 por Vitória Fernandez