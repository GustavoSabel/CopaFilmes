import React from 'react';
import './FilmeCheck.css'

function FilmeCheck(props) {
  return (
      <div className="filmecheck" onClick={() => props.onChange()}>
        <div className="filmecheck-check">
          <input type="checkbox" className="check" checked={props.selecionado}></input>
        </div>
        <div className="filmecheck-detalhes">
          <div className="filmecheck-detalhes-titulo">
            <span>{props.titulo}</span>
          </div>
          <div className="filmecheck-detalhes-ano">
            <span>{props.ano}</span>
          </div>
        </div>
      </div>
    );
}

export default FilmeCheck;