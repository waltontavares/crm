import axios from "axios";


export const axiosInstance = axios.create({

    baseURL: "http://localhost:5066"
})

export class BancoService{

    listarTodos(){
        return axiosInstance.get("/api/Banco");

    }
}