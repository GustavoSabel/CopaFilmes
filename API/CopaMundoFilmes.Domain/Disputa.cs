namespace CopaMundoFilmes.Domain
{
    public class Disputa
    {
        private Disputa(Filme filmeVencedor, Filme filmePerdedor)
        {
            Vencedor = filmeVencedor;
            Perdedor = filmePerdedor;
        }

        public Filme Vencedor { get; }
        public Filme Perdedor { get; }

        public static Disputa Disputar(Filme a, Filme b)
        {
            if (a.Nota >= b.Nota)
                return new Disputa(a, b);
            else
                return new Disputa(b, a);
        }
    }
}
