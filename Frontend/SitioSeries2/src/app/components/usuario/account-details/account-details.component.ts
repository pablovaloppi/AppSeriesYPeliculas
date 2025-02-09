import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

import { AuthService } from 'src/app/core/services/auth.service';
import { LogoutComponent } from '../logout/logout.component';
import { ActualUserRouteService } from 'src/app/core/services/component-comunication/actual-user-route.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css'],
})
export class AccountDetailsComponent implements OnInit {
 
  constructor(
    private authService: AuthService,
    private readonly router: Router,
    private readonly dialog: MatDialog,
    private readonly _actualUserRoute:ActualUserRouteService
    
  ) {}
  ngOnInit(): void {
    this._actualUserRoute.setTitleRoute("Profile")
    this._actualUserRoute.setBackRoute("")

  }
  onLogout() {
    // this.authService.logout();
    // this.router.navigateByUrl('/home');

    this.dialog.open(LogoutComponent, {
      width:'100%',
      maxWidth:'100%',
      height:'max-content',
      position:{
        bottom:'0'
      }
    })
  }
}
