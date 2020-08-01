import React, {useState} from 'react';
import './App.css';
import SelecaoPage from './pages/SelecaoPage';
import ResultadoFinalPage from './pages/ResultadoFinalPage';
import Axios from 'axios'

function App() {
  Axios.defaults.baseURL = 'http://localhost:5000'

  let [vencedores, setVencedores] = useState(null);

  return (
    <div className="app">
      {vencedores 
        ? (<ResultadoFinalPage vencedores={vencedores} novoJogo={() => setVencedores(null)}></ResultadoFinalPage>) 
        : (<SelecaoPage aoFinalizarTorneio={v => setVencedores(v)}></SelecaoPage>)}
    </div>
  );
}

export default App;
