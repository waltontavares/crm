import axios from "axios";


export const axiosInstance = axios.create({

    baseURL: "http://localhost:5066"
})

export class ClausulaService{

    listarTodos(){
        return axiosInstance.get("/api/Clausula");

    }
}