import { Usuario } from "./Usuario";

export interface Respuesta {
    isSuccess: boolean,
    message: string,
    result: Usuario[]
}