import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SerieFavorita } from '../models/serieFavorita';

@Injectable({
  providedIn: 'root'
})
export class SerieFavoritaService {
  private apiPath = environment.api;

  constructor( private http:HttpClient) { }

  agregar(serieFavorita:SerieFavorita):Observable<void>{
    return this.http.post<void>(`${this.apiPath}/seriefavorita`, serieFavorita);
  }

  quitar(serieFavorita:SerieFavorita):Observable<void>{
    return this.http.delete<void>(`${this.apiPath}/seriefavorita/${serieFavorita.usuarioId}/${serieFavorita.serieId}`);
  }

  getSerieFavorita(usuarioId:number, serieId:number):Observable<SerieFavorita>{
    return this.http.get<SerieFavorita>(`${this.apiPath}/seriefavorita/${usuarioId}/${serieId}`);
  }
  
  getCountSerieFavorita(usuarioId:number): Observable<number> | Observable<number> {
    return this.http.get<number>(`${this.apiPath}/seriefavorita?usuarioId=${usuarioId}&serieId=0&count=true`);
  }
}
