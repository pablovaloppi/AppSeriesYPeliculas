import { Category } from './category';

export interface Serie{
    id?: number;
    titulo: string;
    descripcion:string;
    puntuacion: number;
    imgPortada: string;
    categoriaId: number;
    nombreCategoria:string;
    anio:number;
    duracion:number;
    temporada:number;
    capitulo:number;
    paisId:number;
    link:string;
    usuarioId:number;
}

