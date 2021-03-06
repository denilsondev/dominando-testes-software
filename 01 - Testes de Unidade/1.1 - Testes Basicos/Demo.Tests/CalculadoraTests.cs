using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var resultado = calculadora.Somar(2, 2);

            //Assert
            Assert.Equal(4, resultado);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(4, 4, 8)]
        [InlineData(5, 6, 11)]
        public void Calculadora_Somar_RetornarValoresSomaCorretos(double v1, double v2, double total)
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var resultado = calculadora.Somar(v1, v2);

            //Assert
            Assert.Equal(total, resultado);
        }

        [Fact]
        public void Calculadora_Somar_NaoDeveSerIgual()
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var resultado = calculadora.Somar(1.1313131313131, 2.23232323);

            //Assert
            Assert.NotEqual(3.3, resultado, 1);
        }

    }
}