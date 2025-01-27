import React, { useState } from "react";
import axios from "axios";

function RelacionamentosAdicionar() {
    const [formData, setFormData] = useState({
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post("http://localhost:5162/api/relacionamento/adicionar", {...formData,}, {
                headers: {
                    'Content-Type': 'application/json', 
                    'Accept': 'application/json' 
                }
            });
            console.log("Dados recebidos:", response.data);
            alert(response.data);
        } catch (error) {
            console.error("Erro ao adicionar pessoa:", error);
        }
        handleClear();
        alert("Pessoa inserida com sucesso!");
    };

    const handleClear = () => {
        setFormData({
            IdPessoa1: '',
            IdPessoa2: "",
            TipoRelacionamento: '',
        });
    };

    return (
        <div className="container">
            <h2>Adicionar Relacionamento</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Pessoa 1:</label>
                    <input
                        type="int"
                        name="IdPessoa1"
                        value={formData.IdPessoa1}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Pessoa 2:</label>
                    <input
                        type="int"
                        name="IdPessoa2"
                        value={formData.IdPessoa2}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Tipo de Relacionamento:</label>
                    <select name="TipoRelacionamento" value={formData.TipoRelacionamento} onChange={handleChange}>
                        <option value="N">Selecione</option>
                        <option value="M">Masculino</option>
                        <option value="F">Feminino</option>
                    </select>
                </div>
                <div>
                    <button type="submit">Adicionar Pessoa</button>
                    <button type="button" onClick={handleClear}>Limpar Campos</button>
                </div>
            </form>
        </div>

    );
}

export default RelacionamentosAdicionar;
