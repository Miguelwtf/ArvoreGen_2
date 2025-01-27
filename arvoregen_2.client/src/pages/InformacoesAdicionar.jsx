import React, { useState } from "react";
import axios from "axios";

function InformacoesAdicionar() {
    const [formData, setFormData] = useState({
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post("http://localhost:5162/api/pessoa/adicionar", {...formData,}, {
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
            Nome: '',
            DataNascimento: "",
            Sexo: '',
        });
    };

    return (
        <div className="container">
            <h2>Adicionar Pessoa</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Nome de Solteiro:</label>
                    <input
                        type="text"
                        name="Nome"
                        value={formData.Nome}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Data de Nascimento:</label>
                    <input
                        type="date"
                        name="DataNascimento"
                        value={formData.DataNascimento}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Sexo:</label>
                    <select name="Sexo" value={formData.Sexo} onChange={handleChange}>
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

export default InformacoesAdicionar;
