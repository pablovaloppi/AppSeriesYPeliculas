export interface User {
    idUsuario: number;
    user:string;
    nombre: string;
    apellido: string;
    email:string;
    edad: number;
    direccion:string;
    idPais: number;
    tipoUsuarioId: number;
    imgPerfil: string;
}

export enum UserType{
    ADMINISTRATOR = 3,
    MODERATOR = 2,
    COMMON = 1
}