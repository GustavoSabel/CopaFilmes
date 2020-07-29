using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace CopaMundoFilmes.Domain
{
    public class Copa
    {
        private readonly List<Filme> _filmes;
        private readonly int _limiteFilmes;

        public IReadOnlyList<Filme> Filmes => _filmes.ToList();

        public Copa(int limiteFilmes)
        {
            if (limiteFilmes < 2)
                throw new ArgumentException($"{nameof(limiteFilmes)} deve ser 2 ou maior");

            if (limiteFilmes % 2 != 0)
                throw new ArgumentException($"{nameof(limiteFilmes)} deve ser par, mas recebeu o valor {limiteFilmes}");

            _filmes = new List<Filme>();
            _limiteFilmes = limiteFilmes;
        }

        public void Add(Filme filme)
        {
            if (_filmes.Count == _limiteFilmes)
                throw new DominioException($"A Copa não pode ter mais que {_limiteFilmes} filmes");
            _filmes.Add(filme);
        }

        public Vencedores ExecutarDisputas()
        {
            if (_filmes.Count != _limiteFilmes)
                throw new DominioException($"A Copa deveria ter {_limiteFilmes} filmes, mas tem somente {_filmes.Count}");

            var filmesOrdenados = _filmes.OrderBy(x => x.Titulo).ToList();
            return ExecutarDisputas(filmesOrdenados);
        }

        private Vencedores ExecutarDisputas(IReadOnlyList<Filme> filmes)
        {
            if (filmes.Count > 2)
            {
                var vencedores = new List<Filme>();
                for (int i = 0; i < (filmes.Count / 2); i++)
                {
                    var primeiroFilme = filmes[i];
                    var ultimoFilme = filmes[filmes.Count - 1 - i];
                    var disputa = Disputa.Disputar(primeiroFilme, ultimoFilme);
                    vencedores.Add(disputa.Vencedor);
                }
                return ExecutarDisputas(vencedores);
            }
            else
            {
                var disputa = Disputa.Disputar(filmes[0], filmes[1]);
                return new Vencedores(disputa.Vencedor, disputa.Perdedor);
            }
        }
    }
}
