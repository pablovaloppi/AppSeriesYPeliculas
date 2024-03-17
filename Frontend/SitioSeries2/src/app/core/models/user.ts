export interface User {
    idUsuario: number;
    user:string;
    name: string;
    lastName: string;
    email:string;
    age: number;
    direccion:string;
    idPais: number;
    accountType: number;
    imgPerfil: string;
}

export enum UserType{
    ADMINISTRATOR = 3,
    MODERATOR = 2,
    COMMON = 1
}