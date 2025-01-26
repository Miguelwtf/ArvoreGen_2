import React, { useState } from "react";
import axios from "axios";

function PessoasAdicionar() {
    const [formData, setFormData] = useState({
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post("http://localhost:5162/api/pessoa/adicionar", {
                ...formData,
                datacriacao: new Date().toISOString(),
            }, {
                headers: {
                    'Content-Type': 'application/json', 
                    'Accept': 'application/json' 
                }
            });
            console.log("Dados recebidos:", response.data);
            alert(response.data);
        } catch (error) {
            console.error("Erro ao adicionar pessoa:", error);
            //alert("Ocorreu um erro ao adicionar a pessoa. " + error);
        }
    };

    const handleClear = () => {
        setFormData({
            nomesolteiro: '',
            datanascimento: "",
            datafalecimento: "",
            sexo: '',
            localnascimento: '',
            localfalecimento: '',
            nomecasado: '',
            nomealternativo1: '',
            nomealternativo2: '',
            observacao: ''
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
                        name="nomesolteiro"
                        value={formData.nomesolteiro}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Data de Nascimento:</label>
                    <input
                        type="date"
                        name="datanascimento"
                        value={formData.datanascimento}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Data de Falecimento:</label>
                    <input
                        type="date"
                        name="datafalecimento"
                        value={formData.datafalecimento}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Sexo:</label>
                    <select name="sexo" value={formData.sexo} onChange={handleChange}>
                        <option value="N">Selecione</option>
                        <option value="M">Masculino</option>
                        <option value="F">Feminino</option>
                    </select>
                </div>
                <div>
                    <label>Local de Nascimento:</label>
                    <input
                        type="text"
                        name="localnascimento"
                        value={formData.localnascimento}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Local de Falecimento:</label>
                    <input
                        type="text"
                        name="localfalecimento"
                        value={formData.localfalecimento}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Nome Casado:</label>
                    <input
                        type="text"
                        name="nomecasado"
                        value={formData.nomecasado}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Nome Alternativo 1:</label>
                    <input
                        type="text"
                        name="nomealternativo1"
                        value={formData.nomealternativo1}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Nome Alternativo 2:</label>
                    <input
                        type="text"
                        name="nomealternativo2"
                        value={formData.nomealternativo2}
                        onChange={handleChange}
                    />
                </div>
                <div>
                    <label>Observação:</label>
                    <textarea
                        name="observacao"
                        value={formData.observacao}
                        onChange={handleChange}
                    ></textarea>
                </div>
                <div>
                    <button type="submit">Adicionar Pessoa</button>
                    <button type="button" onClick={handleClear}>Limpar Campos</button>
                </div>
            </form>
        </div>

    );
}

export default PessoasAdicionar;
