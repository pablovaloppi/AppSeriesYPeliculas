import { Injectable } from '@angular/core';
import { Serie } from '../models/serie';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class SerieService {

   changeList$ = new BehaviorSubject({} as Serie[]);

  constructor(private readonly http: HttpClient,
    private readonly authService:AuthService) { }

  apiPath: string = environment.api;

  getAll(pageNumber:number = 1 ,pageSize:number = 10): Observable<Serie[]> {
    return this.http.get<Serie[]>(`${this.apiPath}/serie?pageNumber=${pageNumber}&pageSize=${pageSize}`);
  }

  getAllWithHeaders(pageNumber:number = 1, pageSize:number = 10): Observable<any>{
    const httpOptions = { headers: new HttpHeaders({'x-pagination': 'application/json'}),
    observe: 'response' as 'response'};

    return this.http.get<any>(`${this.apiPath}/serie?pageNumber=${pageNumber}&pageSize=${pageSize}`, httpOptions);
  }


  getById(id: number): Observable<Serie> {
    return this.http.get<Serie>(`${this.apiPath}/serie/${id}`);
  }

  getAllByCategory(idCategory?:number): Observable<Serie[]>{
    return this.http.get<Serie[]>(`${this.apiPath}/serie?CategoriaId=${idCategory}`);
  } 

  create(serie: Serie):Observable<Serie>{
    return this.http.post<Serie>(`${this.apiPath}/serie`, serie);
  }

  delete(id:number):Observable<void>{
    return this.http.delete<void>(`${this.apiPath}/serie/${id}`);
  }

  edit(id:number, serie:Serie):Observable<void>{
    return this.http.put<void>(`${this.apiPath}/serie/${id}`, serie);
  }
}
