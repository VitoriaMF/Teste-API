using Teste.API.Models;
using Teste.API.Services.Interfaces;

namespace Teste.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly List<Produto> _products = new();

    public void AddProduct(Produto p)
    {
        if (_products.Exists(x => x.Id == p.Id))
            throw new ArgumentException("Produto com ID duplicado.");
        _products.Add(p);
    }

    public void RemoveProduct(int productId)
    {
        var product = _products.Find(x => x.Id == productId);
        if (product == null)
            throw new KeyNotFoundException("Produto não encontrado.");
        _products.Remove(product);
    }

    public void UpdateQuantity(int productId, int newQuantity)
    {
        var product = _products.Find(x => x.Id == productId);
        if (product == null)
            throw new KeyNotFoundException("Produto não encontrado.");
        if (newQuantity < 0)
            throw new ArgumentException("Quantidade não pode ser negativa.");
        product.Quantity = newQuantity;
    }

    public Produto GetProduct(int productId)
    {
        var product = _products.Find(x => x.Id == productId);
        if (product == null)
            throw new KeyNotFoundException("Produto não encontrado.");
        return product;
    }

    public void SellProduct(int productId, int amount)
    {
        var product = _products.Find(x => x.Id == productId);
        if (product == null)
            throw new KeyNotFoundException("Produto não encontrado.");
        if (amount <= 0)
            throw new ArgumentException("Quantidade de venda deve ser positiva.");
        if (product.Quantity < amount)
            throw new InvalidOperationException("Estoque insuficiente.");
        product.Quantity -= amount;
    }

    public IEnumerable<Produto> GetAll() => _products;
}
}