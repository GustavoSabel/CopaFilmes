import React, { useState, useEffect } from 'react';
import Header from '../components/Header'
import FilmeService from '../services/FilmeService';
import CopaService from '../services/CopaService';
import Filmes from '../components/Filmes';

function SelecaoPage(props) {
  const [filmes, setFilmes] = useState([]);

  useEffect(() => {
    const fetchData = async () => setFilmes(await FilmeService.ObterTodos());
    fetchData();
  }, []);

  return (
    <div>
      <Header fase="Fase de Seleção" descricao="Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir"></Header>
      <div className="selecao-detalhes">
        <div className="selecao-detalhes-texto">
          <span>Selecionado</span><br/>
          <span>{filmes.filter(x => x.selecionado === true).length} de 8 filmes</span>
        </div>
        <div>
          <button className="botao" onClick={() => realizarDisputa()}>GERAR MEU CAMPEONATO</button>
        </div>
      </div>
      <Filmes filmes={filmes} handleChangeCheck={handleChangeCheck} />
    </div>
  );

  async function realizarDisputa() {
    var vencedores = await CopaService.Disputar(filmes.filter(x => x.selecionado));
    props.aoFinalizarTorneio(vencedores);
  }

  function handleChangeCheck(filme) {
    const novaLista = filmes.map((item) => {
      if (item.id === filme.id) {
        return { ...item, selecionado: !filme.selecionado };
      }
      return item;
    });
    setFilmes(novaLista);
  }
}

export default SelecaoPage;