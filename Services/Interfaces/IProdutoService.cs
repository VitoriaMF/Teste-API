using Teste.API.Models;

namespace Teste.API.Services.Interfaces
{
    public interface IProdutoService
    {
        void AddProduct(Produto produto);
        void RemoveProduct(int productId);
        void UpdateQuantity(int productId, int newQuantity);
        Produto GetProduct(int productId);
        void SellProduct(int productId, int amount);
        IEnumerable<Produto> GetAll();
    }
}