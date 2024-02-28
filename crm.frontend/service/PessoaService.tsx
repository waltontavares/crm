import axios from "axios";
import { BaseService } from "./BaseService";

export const axiosInstance = axios.create({
    baseURL: process.env.NEXT_PUBLIC_BACKEND_URL_API
})

export class PessoaService extends BaseService{

    constructor(){
        super( "/api/Pessoa");
    }

    BuscarPessoaCpf(cpf: string){
        return axiosInstance.get("/api/Pessoa/" + cpf);
    }
}