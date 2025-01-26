import { Routes, Route } from 'react-router-dom';

import React from 'react';
import Sidebar from './components/Sidebar';  

import Home from './pages/Home'; 
import Pessoas from './pages/Pessoas';
import Relacionamentos from './pages/Relacionamentos';
import PessoasVisualizar from './pages/PessoasVisualizar';
import PessoasAdicionar from './pages/PessoasAdicionar';

const App = () => {
    return (
        <div className="d-flex">
            <Sidebar />
            <div className="flex-grow-1" style={{ marginLeft: "250px" }}> 
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/pessoas" element={<Pessoas />} />
                    <Route path="/pessoas/visualizar" element={<PessoasVisualizar />} />
                    <Route path="/pessoas/adicionar" element={<PessoasAdicionar />} />
                    <Route path="/relacionamentos" element={<Relacionamentos />} />
                </Routes>
            </div>
        </div>
    );
};

export default App;
