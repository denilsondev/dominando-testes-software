using System;
using Xunit;

namespace Demo.Tests
{
    public class FuncionarioTests
    {
        [Fact]
        public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
        {
            //Arrange & Act
            var funcionario = new Funcionario("", 1000);

            //Assert
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
        }

        [Fact]
        public void Funcionario_Nome_NaoDeveTerApelido()
        {
            //Arrange & Act
            var funcionario = new Funcionario("Denilson", 1000);

            //Assert
            Assert.Null(funcionario.Apelido);

            //Assert Bool
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
            Assert.False(funcionario.Apelido?.Length > 0);
        }


        [Theory]
        [InlineData(700)]
        [InlineData(1500)]
        [InlineData(2000)]
        [InlineData(7500)]
        [InlineData(8000)]
        [InlineData(15000)]
        public void Funcionario_Salario_FaixasSalariaisDevemRespeitarNivelProfissional(double salario)
        {
            //Arrange & Act
            var funcionario = new Funcionario("Denilson", salario);

            //Assert
                 // Assert
            if (funcionario.NivelProfissional == NivelProfissional.Junior)
                Assert.InRange(funcionario.Salario, 500, 1999);

            if (funcionario.NivelProfissional == NivelProfissional.Pleno)
                Assert.InRange(funcionario.Salario, 2000, 7999);

            if (funcionario.NivelProfissional == NivelProfissional.Senior)
                Assert.InRange(funcionario.Salario, 8000, double.MaxValue);

            Assert.NotInRange(funcionario.Salario, 0, 499);
        }

        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario()
        {
            //Arrannge e Act
            var funcionario = FuncionarioFactory.Criar("Denilson",10000);

            //Assert
            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoDerivadoPessoa()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Eduardo", 10000);

            // Assert
            Assert.IsAssignableFrom<Pessoa>(funcionario);
        }

                [Fact]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Eduardo", 10000);

            // Assert
            Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade)));
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadeBasica()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Eduardo", 1000);

            // Assert
            Assert.Contains("OOP", funcionario.Habilidades);
        }


        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadeAvancada()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Eduardo", 1000);

            // Assert
            Assert.DoesNotContain("Microservices", funcionario.Habilidades);
        }


        [Fact]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
        {
            // Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Eduardo", 15000);

            var habilidadesBasicas = new []
            {
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            };

            // Assert
            Assert.Equal(habilidadesBasicas, funcionario.Habilidades);
        }

                [Fact]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
        }


        [Fact]
        public void Funcionario_Salario_DeveRetornarErroSalarioInferiorPermitido()
        {
            // Arrange & Act & Assert
            var exception =
                Assert.Throws<Exception>(() => FuncionarioFactory.Criar("Eduardo", 250));

            Assert.Equal("Salario inferior ao permitido", exception.Message);
        }
        
    }
}