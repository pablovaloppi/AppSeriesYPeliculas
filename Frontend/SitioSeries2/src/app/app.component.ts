import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserService } from './core/services/user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {

  userAdmin!: Observable<boolean>; 

  constructor(private readonly userService: UserService){}
  
  ngOnInit(): void {
    //this.userAdmin = this.userService.idAdminOrModerator();
  }
  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }
}
