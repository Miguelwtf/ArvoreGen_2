﻿import React, { useState, useEffect } from "react";
import axios from "axios";

const PessoasVisualizar = () => {
    const [pessoas, setPessoas] = useState([]);

    /* Visualizar Pessoas */
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

    /* Deletar Pessoas */
    const handleDelete = async (idPessoa) => {
        const confirmDelete = window.confirm("Tem certeza que deseja excluir esta pessoa?");
        if (!confirmDelete) return;

        try {
            await axios.delete(`http://localhost:5162/api/pessoa/excluir/${idPessoa}`);
        } catch (error) {
            console.error("Erro ao excluir pessoa:", error);
        }
        alert("Pessoa excluída com sucesso!");
        setPessoas(pessoas.filter((pessoa) => pessoa.idPessoa !== idPessoa));
    };

    /* Editar Pessoas */
    const handleEdit = (idPessoa) => {
        window.location.href = `/pessoa/editar/${idPessoa}`;
    };

    return (
        <div className="container">
            <h1>Visualizar Pessoas</h1>
            <table className="table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome Solteiro</th>
                        <th>Sexo</th>
                        <th>Data Nascimento</th>
                        <th>Editar</th>
                        <th>Excluir</th>
                    </tr>
                </thead>
                <tbody>
                    {pessoas.length > 0 ? (
                        pessoas.map((pessoa) => (
                            <tr key={pessoa.idPessoa}>
                                <td>{pessoa.idPessoa}</td>
                                <td>{pessoa.nome}</td>
                                <td>{pessoa.sexo}</td>
                                <td>{pessoa.dataNascimento}</td>
                                <td><button className="btn btn-info" onClick={() => handleEdit(pessoa.idPessoa)}>-</button> </td>
                                <td><button className="btn btn-danger" onClick={() => handleDelete(pessoa.idPessoa)}>X</button> </td>
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
