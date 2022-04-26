
using System;
using System.Linq;
using NerdStore.Vendas.Application.Commands;
using Xunit;

namespace NerdStore.Vendas.Application.Tests
{
    public class AdicionarItemPedidoCommandTests
    {
        [Fact]
        public void AdicionarItemPedidoCommand_CommandoEstaValido_DevePassarNaValidacao()
        {
            // Arrange
            var pedidoCommand = new AdicionarItemPedidoCommand(Guid.NewGuid(),
                Guid.NewGuid(), "Produto Teste", 2, 100);

            // Act
            var result = pedidoCommand.EhValido();

            //Assert
            Assert.True(result);
        }

    }
}
