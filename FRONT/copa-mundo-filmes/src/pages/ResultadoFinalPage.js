import React, { useState, useEffect } from 'react';
import Header from '../components/Header'
import FilmeVencedorCaixa from '../components/FilmeVencedorCaixa'

function ResultadoFinalPage() {
  const [vencedores, setVencedores] = useState({
    campeao:{titulo:'Filme A'},
    viceCampeao:{titulo:'Filme B'},
  });

  // useEffect(() => {
  //   const fetchData = async () => setFilmes(await FilmeService.ObterTodos());
  //   fetchData();
  // }, []);

  return (
    <div>
      <Header fase="Resultado final" descricao="Veja o resultado final do Campeonato de filmes de forma simples e rápida"></Header>
      <div className="filmesvencedores">
        <FilmeVencedorCaixa titulo={vencedores.campeao.titulo} colocado={1} />
        <FilmeVencedorCaixa titulo={vencedores.viceCampeao.titulo} colocado={2} />
      </div>
    </div>
  );
}

export default ResultadoFinalPage;