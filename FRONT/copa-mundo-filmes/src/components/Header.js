import React from 'react';
import './Header.css'

function Header(props) {
  return (
      <div>
        <div className="header">
          <div className="header-titulo"><span>CAMPEONATO DE FILMES</span></div>
          <h1 className="header-fase">{props.fase}</h1>
          <div className="header-traco"></div>
          <div className="header-descricao"><span>{props.descricao}</span></div>
        </div>
      </div>
    );
}

export default Header;