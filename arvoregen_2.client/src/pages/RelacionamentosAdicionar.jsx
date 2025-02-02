import React, { useState, useEffect } from "react";
import axios from "axios";

function RelacionamentosAdicionar() {
    const [formData, setFormData] = useState({
        IdPessoa1: '',
        IdPessoa2: '',
        TipoRelacionamento: ''
    });

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

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post("http://localhost:5162/api/relacionamento/adicionar", formData, {
                headers: {
                    'Content-Type': 'application/json',
                    'Accept': 'application/json'
                }
            });
            console.log("Dados recebidos:", response.data);
            alert(response.data);
        } catch (error) {
            console.error("Erro ao adicionar relacionamento:", error);
        }
        handleClear();
    };

    const handleClear = () => {
        setFormData({
            IdPessoa1: '',
            IdPessoa2: '',
            TipoRelacionamento: ''
        });
    };

    return (
        <div className="container">
            <h2>Adicionar Relacionamento</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Pessoa 1:</label>
                    <select name="IdPessoa1" value={formData.IdPessoa1} onChange={handleChange} required>
                        <option value="">Selecione</option>
                        {pessoas.map((pessoa) => (
                            <option key={pessoa.idPessoa} value={pessoa.idPessoa}>
                                {pessoa.nome}
                            </option>
                        ))}
                    </select>
                </div>
                <div>
                    <label>Pessoa 2:</label>
                    <select name="IdPessoa2" value={formData.IdPessoa2} onChange={handleChange} required>
                        <option value="">Selecione</option>
                        {pessoas.map((pessoa) => (
                            <option key={pessoa.idPessoa} value={pessoa.idPessoa}>
                                {pessoa.nome}
                            </option>
                        ))}
                    </select>
                </div>
                <div>
                    <label>Tipo de Relacionamento:</label>
                    <select name="TipoRelacionamento" value={formData.TipoRelacionamento} onChange={handleChange}>
                        <option value="">Selecione</option>
                        <option value="1">Pai</option>
                        <option value="2">Mãe</option>
                        <option value="3">Filho(a)</option>
                        <option value="4">Outro</option>
                    </select>
                </div>
                <div>
                    <button type="submit">Adicionar Relacionamento</button>
                    <button type="button" onClick={handleClear}>Limpar Campos</button>
                </div>
            </form>
        </div>
    );
}

export default RelacionamentosAdicionar;
