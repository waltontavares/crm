import axios from "axios";


export const axiosInstance = axios.create({

    baseURL: "http://localhost:5066"
})

export class EnderecoService{

    BuscarEnderecoCep(Cep: string){
        return axiosInstance.get("/api/Endereco/" + Cep);

    }

}