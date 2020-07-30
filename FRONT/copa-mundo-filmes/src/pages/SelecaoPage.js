import React, { useState } from 'react';
import Header from '../components/Header'
import FilmeCheck from '../components/FilmeCheck';

function SelecaoPage() {
  const [filmes, setFilmes] = useState([
    {id:'1', titulo:'Filme A', ano: 2018},
    {id:'1', titulo:'Filme B', ano: 2018},
    {id:'1', titulo:'Filme C', ano: 2018},
    {id:'1', titulo:'Filme D', ano: 2018},
    {id:'1', titulo:'Filme E', ano: 2018},
    {id:'1', titulo:'Filme F', ano: 2018},
    {id:'1', titulo:'Filme F', ano: 2018},
    {id:'1', titulo:'Filme F', ano: 2018},
    {id:'1', titulo:'Filme F', ano: 2018},
    {id:'1', titulo:'Filme F', ano: 2018},
    {id:'1', titulo:'Filme F', ano: 2018},
  ]);

  return (
    <div>
      <Header fase="Fase de Seleção" descricao="Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para prosseguir"></Header>
      <div className="filmes">
        {filmes.map(x => <FilmeCheck {...x}></FilmeCheck>)}
      </div>
    </div>
  );
}

export default SelecaoPage;