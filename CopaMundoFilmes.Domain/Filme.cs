namespace CopaMundoFilmes.Domain
{
    public class Filme
    {
        public Filme(string id, string titulo, int ano, decimal nota)
        {
            Id = id;
            Titulo = titulo;
            Ano = ano;
            Nota = nota;

            if (nota < 0)
                throw new DominioException("Nota não pode ser menor que zero");
            if(nota > 10)
                throw new DominioException("Nota não pode ser maior que dez");
        }

        public string Id { get; }
        public string Titulo { get; }
        public int Ano { get; }
        public decimal Nota { get; }
    }
}
