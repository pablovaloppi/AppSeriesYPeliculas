import { Injectable } from '@angular/core';
import { User, UserType } from '../models/user';
import { Observable  } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserCration } from '../models/userCreation';
import { UserUpdate } from '../models/userUpdate';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiPath:string = environment.api;

  constructor(private readonly http:HttpClient) { }

  getById(id: number):Observable<User>{
    return this.http.get<User>(`${this.apiPath}/usuario/${id}`);
  }

  getAll():Observable<User[]>{
    return this.http.get<User[]>(`${this.apiPath}/usuario`)
  }
  
  getAllWithHeaders(pageNumber:number = 1, pageSize:number = 10): Observable<any>{
    const httpOptions = { headers: new HttpHeaders({'x-pagination': 'application/json'}),
    observe: 'response' as 'response'};

    return this.http.get<any>(`${this.apiPath}/usuario?pageNumber=${pageNumber}&pageSize=${pageSize}`, httpOptions);
  }
  
  create(user:UserCration):Observable<User>{
    return this.http.post<User>(`${this.apiPath}/usuario`, user);
  }

  delete(id:number):Observable<User>{
    return this.http.delete<User>(`${this.apiPath}/usuario/${id}`);
  }

  update(user:User, id:number): Observable<void>{
    return this.http.put<void>(`${this.apiPath}/usuario/${id}`, user);
  }

  isAdminOrMod(idTypeUser:number):boolean{
    return idTypeUser !== UserType.COMMON;
  }
}
