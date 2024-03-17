import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  private apiPath:string = environment.api;

  constructor(private readonly http:HttpClient) { }

  upload(formData:FormData):Observable<any>{
    return this.http.post(`${this.apiPath}/upload`, formData, {reportProgress:true, observe:'events'});
  }
}
