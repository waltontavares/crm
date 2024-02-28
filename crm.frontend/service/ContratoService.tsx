import axios from "axios";
import { BaseService } from "./BaseService";

export const axiosInstance = axios.create({
    baseURL: process.env.NEXT_PUBLIC_BACKEND_URL_API
})

export class ContratoService extends BaseService{

    constructor(){
        super( "/api/Contrato");
    }

    BuscarContrato(contrato: string, pessoa: number, banco: number){
        return axiosInstance.get("/api/Contrato/" + contrato);
    }
}