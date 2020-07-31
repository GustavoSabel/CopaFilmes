import React from 'react'
import './FilmeVencedorCaixa.css'

function FilmeVencedorCaixa(props) {
  return (
    <div className="filmevencedorcaixa">
      <div className="filmevencedorcaixa-colocado">
        <label>{props.colocado}º</label>
      </div>
      <div className="filmevencedorcaixa-titulo">
        <label>{props.titulo}</label>
      </div>
    </div>
  );
}

export default FilmeVencedorCaixa;