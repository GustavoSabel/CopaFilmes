namespace CopaMundoFilmes.Domain
{
    public class Vencedores
    {
        public Vencedores(Filme campeao, Filme viceCampeao)
        {
            Campeao = campeao;
            ViceCampeao = viceCampeao;
        }

        public Filme Campeao { get; }
        public Filme ViceCampeao { get; }
    }
}
