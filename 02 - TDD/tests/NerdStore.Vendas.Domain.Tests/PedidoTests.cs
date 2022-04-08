using System;
using Xunit;
using NerdStore.Vendas.Domain;
using System.Linq;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoTests
    {
        [Fact(DisplayName = "Adicionar Item Novo PEdido")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_NovoPEdido_DeveAtualizarValor()
        {
            //Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "Produto Teste", 2, 100);

            //Act
            pedido.AdicionarItem(pedidoItem);

            //Assert
            Assert.Equal(200, pedido.ValorTotal);
        }

        [Fact(DisplayName = "Adicionar Item pedidos existentes")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_NovoPEdido_SeMEsmoProdutoSoAtualizarValoreQuantidade()
        {
            //Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid()); ;
            var produtoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(produtoId, "Produto Teste", 2, 100);
            var pedidoItem2 = new PedidoItem(produtoId, "Produto Teste", 1, 100);

            //Act
            pedido.AdicionarItem(pedidoItem);
            pedido.AdicionarItem(pedidoItem2);

            //Assert
            Assert.Equal(300, pedido.ValorTotal);
            Assert.Equal(1, pedido.PedidoItems.Count);
            Assert.Equal(3, pedido.PedidoItems.FirstOrDefault(p => p.ProdutoId == produtoId).Quantidade);

        }

        [Fact(DisplayName = "Adicionar Item pedido acima de do permitido")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_UnidadesAcimaDoPermitido_DeveRetornarException()
        {
            //Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid()); ;
            var produtoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(produtoId, "Produto Teste", Pedido.MAX_UNIDADES_ITEM + 1, 100);


            //Act & Assert
            Assert.Throws<DomainException>(() => pedido.AdicionarItem(pedidoItem));

        }
    }
}
