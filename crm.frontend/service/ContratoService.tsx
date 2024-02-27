import axios from "axios";


export const axiosInstance = axios.create({

    baseURL: "http://localhost:5066"
})

export class ContratoService{

    listarTodos(){
        return axiosInstance.get("/api/Contrato");

    }

    inserir(contrato: Crm.Contrato){
        const { banco, ...dadosSemBanco } = contrato;
        const { pessoa, ...dadosSemPessoa } = dadosSemBanco;
        console.log(dadosSemPessoa);
        return axiosInstance.post("/api/Pessoa", dadosSemPessoa);

    }

    alterar(contrato: Crm.Pessoa){
        return axiosInstance.put("/api/Pessoa", contrato);

    }

    BuscarContrato(contrato: string, pessoa: number, banco: number){
        return axiosInstance.get("/api/Pessoa/" + contrato);

    }
}