﻿using System;
using Xunit;
using NerdStore.Vendas.Domain;
using System.Linq;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Domain.Tests
{
    public class PedidoItemTests
    {

        [Fact(DisplayName = "Novo item pedido abaixo de do permitido")]
        [Trait("Categoria", "Item Pedido Tests")]
        public void NovoItemPedidoUnidadesAbaixoPermitido_DeveRetornarException()
        {
            //Arrange Act & Assert
            Assert.Throws<DomainException>(() => new PedidoItem(Guid.NewGuid(),"Produto Teste", Pedido.MIN_UNIDADES_ITEM - 1, 100));
        }
    }
}
