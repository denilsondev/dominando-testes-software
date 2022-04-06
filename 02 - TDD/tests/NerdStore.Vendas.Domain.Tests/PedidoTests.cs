using System;
using System.Linq;
using NerdStore.Vendas.Domain;
using Xunit;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoTests
    {
        [Fact(DisplayName = "Adicionar Item Novo PEdido")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_NovoPEdido_DeveAtualizarValor()
        {
            //Arrange
            var pedido = new Pedido();
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "Produto Teste", 2, 100);

            //Act
            pedido.AdicionarItem(pedidoItem);

            //Assert
            Assert.Equal(200, pedido.ValorTotal);
        }
    }
}
