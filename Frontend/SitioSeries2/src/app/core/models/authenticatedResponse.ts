import { UserLogin } from './userLogin';
export interface AuthenticatedResponse{
    usuario:UserLogin;
    token:string;
}