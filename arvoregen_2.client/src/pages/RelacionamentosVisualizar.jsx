import React, { useState, useEffect } from "react";
import axios from "axios";

const RelacionamentosVisualizar = () => {
    const [relacionamentos, setRelacionamentos] = useState([]);

    useEffect(() => {
        const fetchRelacionamentos = async () => {
            try {
                const response = await axios.get("http://localhost:5162/api/relacionamento/visualizar");
                setRelacionamentos(response.data);
            } catch (error) {
                console.error("Erro ao buscar relacionamentos:", error);
            }
        };

        fetchRelacionamentos();
    }, []);

    return (
        <div className="container">
            <h1>Visualizar Relacionamentos</h1>
            <table className="table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Pessoa 1</th>
                        <th>Pessoa 2</th>
                        <th>Tipo de Relacionamento</th>
                        <th>Editar</th>
                        <th>Excluir</th>
                    </tr>
                </thead>
                <tbody>
                    {relacionamentos.length > 0 ? (
                        relacionamentos.map((relacionamento) => (
                            <tr key={relacionamento.IdRelacionamento}>
                                <td>{relacionamento.IdRelacionamento}</td>
                                <td>{relacionamento.Pessoa1Nome}</td>
                                <td>{relacionamento.Pessoa2Nome}</td>
                                <td>{relacionamento.TipoRelacionamento}</td>
                                <td>
                                    <button className="btn btn-info" onClick={() => window.location.href = `/relacionamento/editar/${relacionamento.IdRelacionamento}`}>
                                        Editar
                                    </button>
                                </td>
                                <td>
                                    <button className="btn btn-danger" onClick={() => handleDelete(relacionamento.IdRelacionamento)}>
                                        Excluir
                                    </button>
                                </td>
                            </tr>
                        ))
                    ) : (
                        <tr><td colSpan="6">Nenhum relacionamento encontrado</td></tr>
                    )}
                </tbody>
            </table>
        </div>
    );
};

export default RelacionamentosVisualizar;
