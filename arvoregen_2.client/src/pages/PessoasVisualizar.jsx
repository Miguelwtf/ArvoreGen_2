import React, { useState, useEffect } from "react";
import axios from "axios";

const PessoasVisualizar = () => {
    const [pessoas, setPessoas] = useState([]);

    useEffect(() => {
        const fetchPessoas = async () => {
            try {
                const response = await axios.get("http://localhost:5162/api/pessoa/visualizar");
                console.log("Dados recebidos:", response.data); 
                setPessoas(response.data);
            } catch (error) {
                console.error("Erro ao buscar pessoas:", error);
            }
        };

        fetchPessoas();
    }, []);

    return (
        <div className="container">
            <h1>Visualizar Pessoas</h1>
            <table className="table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome Solteiro</th>
                        <th>Sexo</th>
                        <th>Ação</th>
                    </tr>
                </thead>
                <tbody>
                    {pessoas.length > 0 ? (
                        pessoas.map((pessoa) => (
                            <tr key={pessoa.idpessoa}>
                                <td>{pessoa.idpessoa}</td>
                                <td>{pessoa.nomesolteiro}</td>
                                <td>{pessoa.sexo}</td>
                                <td>[x]</td>
                            </tr>
                        ))
                    ) : (
                        <tr><td colSpan="8">Nenhuma pessoa encontrada</td></tr>
                    )}
                </tbody>
            </table>
        </div>
    );
};

export default PessoasVisualizar;
