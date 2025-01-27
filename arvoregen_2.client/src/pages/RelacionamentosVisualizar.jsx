import React, { useState, useEffect } from "react";
import axios from "axios";

const RelacionamentosVisualizar = () => {
    const [relacionamentos, setRelacionamentos] = useState([]);

    useEffect(() => {
        const fetchRelacionamentos = async () => {
            try {
                const response = await axios.get("http://localhost:5162/api/relacionamento/visualizar");
                console.log("Dados recebidos:", response.data); 
                setPessoas(response.data);
            } catch (error) {
                console.error("Erro ao buscar pessoas:", error);
            }
        };

        fetchRelacionamentos();
    }, []);

    const handleDelete = async (idRelacionamento) => {
        const confirmDelete = window.confirm("Tem certeza que deseja excluir esta pessoa?");
        if (!confirmDelete) return;

        try {
            await axios.delete(`http://localhost:5162/api/relacionamento/excluir/${idPessoa}`);
        } catch (error) {
            console.error("Erro ao excluir pessoa:", error);
        }
        alert("Relacionamentos excluída com sucesso!");
        setPessoas(relacionamento.filter((relacionamento) => relacionamento.idRelacionamento !== idRelacionamento));
    };

    const handleEdit = (idRelacionamento) => {
        window.location.href = `/relacionamento/editar/${idRelacionamento}`;
    };


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
                            <tr key={relacionamento.idrelacionamento}>
                                <td>{relacionamento.idrelacionamento}</td>
                                <td>{relacionamento.idpessoa1}</td>
                                <td>{relacionamento.idpessoa2}</td>
                                <td>{relacionamento.tiporelacionamento}</td>
                                <td><button className="btn btn-info" onClick={() => handleEdit(relacionamento.idRelacionamento)}>-</button> </td>
                                <td><button className="btn btn-danger" onClick={() => handleDelete(relacionamento.idRelacionamento)}>X</button> </td>
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

export default RelacionamentosVisualizar;
