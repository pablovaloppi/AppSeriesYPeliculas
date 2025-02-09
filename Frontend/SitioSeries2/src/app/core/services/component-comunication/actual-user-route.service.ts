import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ActualUserRouteService {

  private $titleRoute: BehaviorSubject<string> = new BehaviorSubject("Profile");
  private $backRoute: BehaviorSubject<string> = new BehaviorSubject("");

  getTitleRoute():Observable<string>{
    return this.$titleRoute.asObservable();
  }

  setTitleRoute(title:string){
    this.$titleRoute.next(title);
  }
  
  getBackRoute():Observable<string>{
    return this.$backRoute.asObservable();
  }

  setBackRoute(route:string){
    this.$backRoute.next(route);
  }
  
  
}
