using System;
using Teste.API.Models;
using Teste.API.Services;
using Xunit;

namespace Teste.API.Tests
{
    public class TestsAPI
    {
        [Fact]
        public void AddProduct_DeveAdicionarProduto()
        {
            var service = new ProdutoService();
            var product = new Produto { Id = 1, Nome = "Produto A", Quantity = 10 };

            service.AddProduct(product);

            var result = service.GetProduct(1);
            Assert.Equal("Produto A", result.Nome);
            Assert.Equal(10, result.Quantity);
        }

        [Fact]
        public void AddProduct_ComIdDuplicado_DeveLancarExcecao()
        {
            var service = new ProdutoService();
            var product1 = new Produto { Id = 1, Nome = "Produto A", Quantity = 10 };
            var product2 = new Produto { Id = 1, Nome = "Produto B", Quantity = 5 };

            service.AddProduct(product1);

            Assert.Throws<ArgumentException>(() => service.AddProduct(product2));
        }
    }
}