import React from 'react';
import './Filmes.css'
import FilmeCheck from './FilmeCheck';

function Filmes(props) {
  return (
    <div className="filmes">
      {props.filmes.map(x => <FilmeCheck key={x.id} {...x} onChange={() => props.handleChangeCheck(x)}></FilmeCheck>)}
    </div>
  )
}

export default Filmes;