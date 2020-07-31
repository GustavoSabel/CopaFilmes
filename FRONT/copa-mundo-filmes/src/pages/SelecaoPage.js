import React, { useState, useEffect } from 'react';
import Header from '../components/Header'
import FilmeCheck from '../components/FilmeCheck';
import FilmeService from '../services/filmeService';

function SelecaoPage() {
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
        <div className="selecao-detalhes-botaogerar">
          <button >GERAR MEU CAMPEONATO</button>
        </div>
      </div>
      <div className="filmes">
        {filmes.map(x => <FilmeCheck key={x.id} {...x} onChange={() => handleChangeCheck(x)}></FilmeCheck>)}
      </div>
    </div>
  );

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