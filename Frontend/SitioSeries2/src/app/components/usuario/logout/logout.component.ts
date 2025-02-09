import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css'],
})
export class LogoutComponent {

  constructor(private dialogRef: MatDialogRef<LogoutComponent>,
    private authService:AuthService,
    private router:Router
  ) {}

  logout(){
    this.authService.logout();
    this.router.navigateByUrl('/home');
    this.cancel();
  }

  cancel(){
    this.dialogRef.close();
  }
}
