import { Routes, Route } from 'react-router-dom';

import React from 'react';
import Sidebar from './components/Sidebar';  

import Home from './pages/Home'; 

import PessoasEditar from './pages/PessoasEditar';
import PessoasAdicionar from './pages/PessoasAdicionar';
import PessoasVisualizar from './pages/PessoasVisualizar';

import RelacionamentosAdicionar from './pages/RelacionamentosAdicionar';
import RelacionamentosVisualizar from './pages/RelacionamentosVisualizar';

import InformacoesAdicionar from './pages/InformacoesAdicionar';
import InformacoesVisualizar from './pages/InformacoesVisualizar';

const App = () => {
    return (
        <div className="d-flex">
            <Sidebar />
            <div className="flex-grow-1" style={{ marginLeft: "250px" }}> 
                <Routes>
                    <Route path="/" element={<Home />} />

                    <Route path="/pessoas/adicionar" element={<PessoasAdicionar />} />
                    <Route path="/pessoas/visualizar" element={<PessoasVisualizar />} />
                    <Route path="/pessoas/editar/:idPessoa" element={<PessoasEditar />} />

                    <Route path="/relacionamentos/adicionar" element={<RelacionamentosAdicionar />} />
                    <Route path="/relacionamentos/visualizar" element={<RelacionamentosVisualizar />} />

                    <Route path="/informacoes/adicionar" element={<InformacoesAdicionar />} />
                    <Route path="/informacoes/visualizar" element={<InformacoesVisualizar />} />
                </Routes>
            </div>
        </div>
    );
};

export default App;
//server -> dotnet run
//client -> npm run dev