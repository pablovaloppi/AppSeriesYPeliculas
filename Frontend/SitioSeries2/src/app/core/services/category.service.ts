import { Injectable } from '@angular/core';
import { Category } from '../models/category';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  // private categories: Category[] = [
  //   {id: 1, name: 'Accion'},{id: 2,name: 'Animacion'},{ id: 3, name: 'Aventuras'},{ id: 4,name: 'Ciencia Ficcion'},
  //   {id: 5,name: 'Drama'},{id: 6,name: 'Romantico'},{id: 7,name: 'Sci Fi'},{id: 8,name: 'Fantasia'},
  // ]
  apiPath:string = environment.api;
  
  constructor(private readonly http:HttpClient) { }

  getAll(): Observable<Category[]>{
    return this.http.get<Category[]>(`${this.apiPath}/category`);
  }
  getAllWithHeaders(pageNumber:number = 1, pageSize:number = 10): Observable<any>{
    const httpOptions = { headers: new HttpHeaders({'x-pagination': 'application/json'}),
    observe: 'response' as 'response'};

    return this.http.get<any>(`${this.apiPath}/category?pageNumber=${pageNumber}&pageSize=${pageSize}`, httpOptions);
  }
  getById(id: number): Observable<Category>{
    
    return this.http.get<Category>(`${this.apiPath}/category/${id}`);
    // let position = this.categories.findIndex(element => element.id === id);

    // if( position != -1){
    //   return this.categories[position];
    // }

    // console.log(`No hay ninguna categoria con el id: ${id}`);
    // return undefined;
  }

  create(categoria: Category):Observable<Category>{
    return this.http.post<Category>(`${this.apiPath}/category`, categoria);
  }
  delete(id:number){
    console.log(id);
    return this.http.delete(`${this.apiPath}/category/${id}`);
  }
  // getIdByName(name:string):number{
  //   let id = this.categories.findIndex((item) => item.name === name);
  //   return id >= 0 ? id + 1 : -1;
  // }
    
  // getNameById(categoryId:number):string | undefined{
  //   return this.categories.find(cat=> cat.id == categoryId)?.name;
  //  }
}

