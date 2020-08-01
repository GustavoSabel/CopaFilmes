import React from 'react';
import Header from '../components/Header'
import FilmeVencedorCaixa from '../components/FilmeVencedorCaixa'

function ResultadoFinalPage(props) {
  return (
    <div>
      <Header fase="Resultado final" descricao="Veja o resultado final do Campeonato de filmes de forma simples e rápida"></Header>
      <div className="filmesvencedores">
        <FilmeVencedorCaixa titulo={props.vencedores.campeao.titulo} colocado={1} />
        <FilmeVencedorCaixa titulo={props.vencedores.viceCampeao.titulo} colocado={2} />
      </div>
      <div className="botao-novo-jogo">
          <button className="botao" onClick={() => props.novoJogo()}>NOVO JOGO</button>
      </div>
    </div>
  );
}

export default ResultadoFinalPage;