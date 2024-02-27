import axios from "axios";


export const axiosInstance = axios.create({

    baseURL: "http://localhost:5066"
})

export class EstadoCivilService{

    listarTodos(){
        return axiosInstance.get("/api/EstadoCivil");

    }
}