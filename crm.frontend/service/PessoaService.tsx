import axios from "axios";


export const axiosInstance = axios.create({

    baseURL: "http://localhost:5066"
})

export class PessoaService{

    listarTodos(){
        return axiosInstance.get("/api/Pessoa");

    }

    inserir(pessoa: Crm.Pessoa){
        const { estado_Civil, ...dadosSemEstadoCivil } = pessoa;
        console.log(dadosSemEstadoCivil);
        return axiosInstance.post("/api/Pessoa", dadosSemEstadoCivil);

    }

    alterar(pessoa: Crm.Pessoa){
        return axiosInstance.put("/api/Pessoa", pessoa);

    }

    BuscarPessoaCpf(cpf: string){
        return axiosInstance.get("/api/Pessoa/" + cpf);

    }
}