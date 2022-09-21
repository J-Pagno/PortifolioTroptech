using ControleEstoque;
using ControleEstoque.Excecoes;
using NUnit.Framework;

namespace ControleDeEstoqueUnitTests.Test
{
    public class ProductTest
    {
        [SetUp]
        public void Setup() { }

        /*Quando acrescentar 5 itens no produto
        E quantidade inicial do produto for 20
        Então deve atualizar quantidade do produto para 25*/

        [Test]
        public void Teste_1_Quando_Add_5_Numeros_Em_Produto_E_Qtd_Inicial_for_20_Qtd_Do_Produto_Igual_25()
        {
            Produto produto = new("Produto", "Produto");

            int initialQuantity = 20;

            produto.AcrescentarQuantidade(initialQuantity);

            int resultAfterAdd = produto.AcrescentarQuantidade(5);

            Assert.AreEqual(25, resultAfterAdd);
        }

        /*Quando acrescentar 0 itens no produto
        E quantidade inicial do produto for 20
        Então não deve atualizar a quantidade de itens do produto*/

        [Test]
        public void Teste_2_Quando_Add_0_Numeros_Em_Produto_E_Qtd_Inicial_for_20_Qtd_Do_Produto_Nao_Atualiza()
        {
            Produto produto = new("Produto", "Produto");

            int initialQuantity = 20;

            produto.AcrescentarQuantidade(initialQuantity);

            Assert.Throws<QuantidadeMenorOuIgualAZeroException>(
                () => produto.AcrescentarQuantidade(0)
            );
        }

        /*Quando acrescentar -5 itens no produto
        E quantidade inicial do produto for 20
        Então não deve atualizar a quantidade de itens do produto*/

        [Test]
        public void Teste_3_Quando_Add_Menos_5_Numeros_Em_Produto_E_Qtd_Inicial_for_20_Qtd_Do_Produto_Nao_Atualiza()
        {
            Produto produto = new("Produto", "Produto");

            int initialQuantity = 20;

            produto.AcrescentarQuantidade(initialQuantity);

            Assert.Throws<QuantidadeMenorOuIgualAZeroException>(
                () => produto.AcrescentarQuantidade(-5)
            );
        }

        /*Quando deduzir 5 itens no produto
        E quantidade inicial do produto for 20
        Então deve atualizar quantidade do produto para 15*/

        [Test]
        public void Teste_4_Quando_Deduzir_5_Em_Produto_E_Qtd_Inicial_for_20_Qtd_Do_Produto_15()
        {
            Produto produto = new("Produto", "Produto");

            int initialQuantity = 20;

            produto.AcrescentarQuantidade(initialQuantity);

            int resultAfterDeduct = produto.DeduzirQuantidade(5);

            Assert.AreEqual(15, resultAfterDeduct);
        }

        /*Quando deduzir 0 itens no produto
        E quantidade inicial do produto for 20
        Então não deve atualizar a quantidade de itens do produto*/

        [Test]
        public void Teste_5_Quando_Deduzir_0_Em_Produto_E_Qtd_Inicial_for_20_Qtd_Do_Produto_Nao_Muda()
        {
            Produto produto = new("Produto", "Produto");

            int initialQuantity = 20;

            produto.AcrescentarQuantidade(initialQuantity);

            Assert.Throws<QuantidadeMenorOuIgualAZeroException>(() => produto.DeduzirQuantidade(0));
        }

        /*Quando deduzir -5 itens no produto
        E quantidade inicial do produto for 20
        Então não deve atualizar a quantidade de itens do produto*/

        [Test]
        public void Teste_6_Quando_Deduzir_Menos_5_Em_Produto_E_Qtd_Inicial_for_20_Qtd_Do_Produto_Nao_Muda()
        {
            Produto produto = new("Produto", "Produto");

            int initialQuantity = 20;

            produto.AcrescentarQuantidade(initialQuantity);

            Assert.Throws<QuantidadeMenorOuIgualAZeroException>(
                () => produto.DeduzirQuantidade(-5)
            );
        }

        /*Quando deduzir 6 itens no produto
        E quantidade inicial do produto for 5
        Então a quantidade atualizada deve ser 0*/

        [Test]
        public void Teste_7_Quando_Deduzir_Menos_6_Em_Produto_E_Qtd_Inicial_for_5_Qtd_Do_Produto_0()
        {
            Produto produto = new("Produto", "Produto");

            int initialQuantity = 5;

            produto.AcrescentarQuantidade(initialQuantity);

            int resultAfterDeduct = produto.DeduzirQuantidade(6);

            Assert.AreEqual(0, resultAfterDeduct);
        }
    }
}
