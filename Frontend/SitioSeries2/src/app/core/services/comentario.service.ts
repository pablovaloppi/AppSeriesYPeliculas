import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Comentario } from '../models/comentario';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ComentarioCreation } from '../models/comentarioCreation';

@Injectable({
  providedIn: 'root'
})
export class ComentarioService {
  apiPath:string = environment.api;
  constructor(private readonly http:HttpClient) { }

  agregar(comentario:ComentarioCreation):Observable<Comentario>{
    return this.http.post<Comentario>(`${this.apiPath}/comentario`, comentario);
  }

  obtener(serieId:number):Observable<Comentario[]>{
    return this.http.get<Comentario[]>(`${this.apiPath}/comentario?PageSize=30&serieId=${serieId}`);
  }
}
