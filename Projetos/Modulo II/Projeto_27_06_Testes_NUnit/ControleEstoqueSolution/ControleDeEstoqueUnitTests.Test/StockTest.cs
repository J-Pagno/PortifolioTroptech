using ControleEstoque;
using ControleEstoque.Excecoes;
using NUnit.Framework;

namespace ControleDeEstoqueUnitTests.Test
{
    public class StockTest
    {
        /*Quando cadastrar produto no estoque
        E produto ainda não existir no estoque
        Então deve concluir cadastro com sucesso*/

        [Test]
        public void Teste_1_Quando_Cadastrar_Produto_Se_Nao_Existe_Concluir_Cadastro()
        {
            Estoque stock = new();

            stock.CadastrarProdutoNoEstoque("Produto", "Cor");

            Assert.Pass();
        }

        /*Quando cadastrar produto no estoque
        E produto já existir no estoque
        Então não deve concluir cadastro*/

        [Test]
        public void Teste_2_Quando_Cadastrar_Produto_Se_Existe_Nao_Concluir_Cadastro()
        {
            Estoque stock = new();

            stock.CadastrarProdutoNoEstoque("Produto", "Cor");

            Assert.Throws<ProdutoJaCadastradoException>(
                () => stock.CadastrarProdutoNoEstoque("Produto", "Cor")
            );
        }

        /*Quando registrar a entrada de produtos no estoque
        E produto não existir no estoque
        Então não deve concluir a ação*/

        [Test]
        public void Teste_3_Quando_Registrar_Produto_Se_Nao_Existe_Nao_Concluir_Registrar()
        {
            Estoque stock = new();

            Assert.Throws<ProdutoNaoEncontradoException>(
                () => stock.RegistrarEntradaDeProduto(1, 2)
            );
        }

        /*Quando registrar a entrada de 5 itens de produtos no estoque
        E produto existir no estoque
        Então deve concluir a ação*/

        [Test]
        public void Teste_4_Quando_Registrar_5_Produtos_Se_Existe_No_Estoque_Concluir_Registrar()
        {
            Estoque stock = new();

            stock.CadastrarProdutoNoEstoque("0", "0");

            Assert.DoesNotThrow(() => stock.RegistrarEntradaDeProduto(0, 5));
        }

        /*Quando registrar a saída de 5 itens de produtos no estoque
        E produto não existir no estoque
        Então não deve concluir a ação*/

        [Test]
        public void Teste_5_Quando_Registrar_5_Produtos_Se_Nao_Existe_No_Estoque_Nao_Concluir_Registrar()
        {
            Estoque stock = new();

            Assert.Throws<ProdutoNaoEncontradoException>(
                () => stock.RegistrarEntradaDeProduto(0, 5)
            );
        }

        /* Quando registrar a saída de 5 itens de produtos no estoque
        E produto existir no estoque com quantidade maior ou igual a 5
        Então deve concluir a ação*/

        [Test]
        public void Teste_6_Quando_Registrar_Saida_5_Produtos_E_Produto_Maior_Igual_5_Concluir()
        {
            Estoque stock = new();

            stock.CadastrarProdutoNoEstoque("Produto", "abc0");

            var produto = stock.RegistrarEntradaDeProduto(0, 15);

            stock.RegistrarSaidaDeProduto(0, 5);
        }

        /*Quando verificar se há itens no estoque
        E quantidade de itens for igual a zero
        Então deve informar que não há*/

        [Test]
        public void Teste_7_Verficar_Se_Ha_Itens_Se_For_Igual_0_Informar_Nao_Ha()
        {
            Estoque stock = new();

            if (!stock.HaProdutosEmEstoque())
                Assert.Pass();
            else
                Assert.Fail("Não há!");
        }

        /*Quando verificar se há itens no estoque
        E quantidade de itens for maior que zero
        Então deve informar que há*/

        [Test]
        public void Teste_8_Verficar_Se_Ha_Itens_E_For_Igual_0_Informar_Nao_Ha()
        {
            Estoque stock = new();

            stock.CadastrarProdutoNoEstoque("Produto", "Primeiro");

            if (stock.HaProdutosEmEstoque())
                Assert.Pass("Não Há");
            else
                Assert.Fail();
        }
    }
}
