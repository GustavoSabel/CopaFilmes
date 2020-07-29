using CopaMundoFilmes.Domain;
using FluentAssertions;
using System;
using Xunit;

namespace CopaMundoFilmes.Test
{
    public class CopaTest
    {
        [Fact]
        public void Menos_filme_que_o_informado()
        {
            var copa = new Copa(4);
            copa.AddFilme(CriarFilme("A", 10));
            copa.AddFilme(CriarFilme("B", 7));

            Action acao = () => copa.ExecutarDisputas();
            acao.Should().Throw<Exception>().And.Message.Should().Contain("tem somente 2");
        }

        [Fact]
        public void Mais_filme_que_o_informado()
        {
            var copa = new Copa(2);
            copa.AddFilme(CriarFilme("A", 10));
            copa.AddFilme(CriarFilme("B", 7));

            Action acao = () => copa.AddFilme(CriarFilme("C", 7));
            acao.Should().Throw<Exception>().And.Message.Should().Contain("não pode ter mais que 2");
        }

        [Fact]
        public void Numero_impar()
        {
            Action acao = () => new Copa(3);
            acao.Should().Throw<Exception>().And.Message.Should().Contain("deve ser par");
        }

        [Fact]
        public void Menor_que_2()
        {
            Action acao = () => new Copa(1);
            acao.Should().Throw<Exception>().And.Message.Should().Contain("deve ser 2 ou maior");
        }

        [Fact]
        public void Com_2_filmes()
        {
            var copa = new Copa(2);
            copa.AddFilme(CriarFilme("A", 10));
            copa.AddFilme(CriarFilme("B", 7));

            var vencedores = copa.ExecutarDisputas();
            vencedores.Campeao.Titulo.Should().Be("A");
            vencedores.ViceCampeao.Titulo.Should().Be("B");
        }

        [Fact]
        public void Com_4_filmes()
        {
            var copa = new Copa(4);
            copa.AddFilme(CriarFilme("A", 10));
            copa.AddFilme(CriarFilme("B", 9));
            copa.AddFilme(CriarFilme("C", 8));
            copa.AddFilme(CriarFilme("D", 7));

            var vencedores = copa.ExecutarDisputas();
            vencedores.Campeao.Titulo.Should().Be("A");
            vencedores.ViceCampeao.Titulo.Should().Be("B");
        }

        [Fact]
        public void Com_8_filmes()
        {
            var copa = new Copa(8);
            copa.AddFilme(CriarFilme("I", 7));
            copa.AddFilme(CriarFilme("H", 2));
            copa.AddFilme(CriarFilme("G", 9)); 
            copa.AddFilme(CriarFilme("F", 10));
            copa.AddFilme(CriarFilme("D", 6.5m));
            copa.AddFilme(CriarFilme("C", 5));
            copa.AddFilme(CriarFilme("B", 4.5m));
            copa.AddFilme(CriarFilme("A", 3));

            var vencedores = copa.ExecutarDisputas();
            vencedores.Campeao.Titulo.Should().Be("F");
            vencedores.ViceCampeao.Titulo.Should().Be("G");
        }

        [Fact]
        public void Empate()
        {
            var copa = new Copa(4);
            copa.AddFilme(CriarFilme("D", 7)); //------------------
            copa.AddFilme(CriarFilme("C", 8)); //Vencedor------|  |
            copa.AddFilme(CriarFilme("B", 2)); //--------------|  |
            copa.AddFilme(CriarFilme("A", 8)); //Vencedor----------

            var vencedores = copa.ExecutarDisputas();
            vencedores.Campeao.Titulo.Should().Be("A");
            vencedores.ViceCampeao.Titulo.Should().Be("C");
        }

        [Fact]
        public void Empate_ordem_asc()
        {
            var copa = new Copa(4);
            copa.AddFilme(CriarFilme("A", 10)); //Vencedor---------
            copa.AddFilme(CriarFilme("B", 2));  //Vencedor-----|  |
            copa.AddFilme(CriarFilme("C", 2));  //-------------|  |
            copa.AddFilme(CriarFilme("D", 10)); //-----------------

            var vencedores = copa.ExecutarDisputas();
            vencedores.Campeao.Titulo.Should().Be("A");
            vencedores.ViceCampeao.Titulo.Should().Be("B");
        }

        [Fact]
        public void Empate_ordem_desc()
        {
            var copa = new Copa(4);
            copa.AddFilme(CriarFilme("D", 10)); //-----------------
            copa.AddFilme(CriarFilme("C", 2));  //-------------|  |
            copa.AddFilme(CriarFilme("B", 2));  //Vencedor-----|  |
            copa.AddFilme(CriarFilme("A", 10)); //Vencedor---------

            var vencedores = copa.ExecutarDisputas();
            vencedores.Campeao.Titulo.Should().Be("A");
            vencedores.ViceCampeao.Titulo.Should().Be("B");
        }

        /// <summary>
        /// Esse foi o exemplo dado no pdf do desafio
        /// </summary>
        [Fact]
        public void Caso_de_teste_do_desafio()
        {
            var copa = new Copa(8);
            copa.AddFilme(CriarFilme("Os Incríveis 2", 8.5m));
            copa.AddFilme(CriarFilme("Jurassic World: Reino Ameaçado", 6.7m));
            copa.AddFilme(CriarFilme("Oito Mulheres e um Segredo", 6.3m));
            copa.AddFilme(CriarFilme("Hereditário", 7.8m));
            copa.AddFilme(CriarFilme("Vingadores: Guerra Infinita", 8.8m));
            copa.AddFilme(CriarFilme("Deadpool 2", 8.1m));
            copa.AddFilme(CriarFilme("Han Solo: Uma História Star Wars", 7.2m));
            copa.AddFilme(CriarFilme("Thor: Ragnarok", 7.9m));

            var vencedores = copa.ExecutarDisputas();
            vencedores.Campeao.Titulo.Should().Be("Vingadores: Guerra Infinita");
            vencedores.ViceCampeao.Titulo.Should().Be("Os Incríveis 2");
        }


        private static Filme CriarFilme(string nome, decimal nota)
        {
            return new Filme("0", nome, 2000, nota);
        }
    }
}
