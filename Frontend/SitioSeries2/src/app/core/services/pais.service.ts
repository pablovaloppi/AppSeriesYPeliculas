import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Pais } from '../models/pais';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PaisService {

  private apiPath:string = environment.api;
  constructor( private readonly htpp: HttpClient) { }

  getAll():Observable<Pais[]>{
    return this.htpp.get<Pais[]>( `${this.apiPath}/pais`);
  }
}
