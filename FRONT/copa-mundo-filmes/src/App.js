import React, { useState } from 'react';
import './App.css';
import SelecaoPage from './pages/SelecaoPage';
import ResultadoFinalPage from './pages/ResultadoFinalPage';
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';

function App() {
  let [vencedores, setVencedores] = useState(null);

  return (
    <div className="app">
      {vencedores
        ? (<ResultadoFinalPage vencedores={vencedores} novoJogo={() => setVencedores(null)}></ResultadoFinalPage>)
        : (<SelecaoPage aoFinalizarTorneio={v => setVencedores(v)}></SelecaoPage>)}
      <ToastContainer />
    </div>
  );
}

export default App;
