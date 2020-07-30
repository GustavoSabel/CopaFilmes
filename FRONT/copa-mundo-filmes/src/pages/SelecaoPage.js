import React, { useState } from 'react';
import Header from '../components/Header'
import FilmeCheck from '../components/FilmeCheck';

function SelecaoPage() {
  const [filmes, setFilmes] = useState([
    { id: '1', titulo: 'Filme A', ano: 2018, selecionado: false },
    { id: '2', titulo: 'Filme B', ano: 2018, selecionado: false },
    { id: '3', titulo: 'Filme C', ano: 2018, selecionado: false },
    { id: '4', titulo: 'Filme D', ano: 2018, selecionado: false },
    { id: '5', titulo: 'Filme E', ano: 2018, selecionado: false },
    { id: '6', titulo: 'Filme F', ano: 2018, selecionado: false },
    { id: '7', titulo: 'Filme F', ano: 2018, selecionado: false },
    { id: '8', titulo: 'Filme F', ano: 2018, selecionado: false },
    { id: '9', titulo: 'Filme F', ano: 2018, selecionado: false },
    { id: '10', titulo: 'Filme F', ano: 2018, selecionado: false },
    { id: '11', titulo: 'Filme F', ano: 2018, selecionado: false },
  ]);

  return (
    <div>
      <Header fase="Fase de Seleção" descricao="Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir"></Header>
      <div className="selecao-detalhes">
        <div className="selecao-detalhes-texto">
          <span>Selecionado</span><br/>
          <span>{filmes.filter(x => x.selecionado).length} de 8 filmes</span>
        </div>
        <div className="selecao-detalhes-botaogerar">
          <button >GERAR MEU CAMPEONATO</button>
        </div>
      </div>
      <div className="filmes">
        {filmes.map(x => <FilmeCheck {...x} onChange={() => handleChangeCheck(x)}></FilmeCheck>)}
      </div>
    </div>
  );

  function handleChangeCheck(filme) {
    const novaLista = filmes.map((item) => {
      if (item.id == filme.id) {
        return { ...item, selecionado: !filme.selecionado };
      }
      return item;
    });
    setFilmes(novaLista);
  }
}

export default SelecaoPage;