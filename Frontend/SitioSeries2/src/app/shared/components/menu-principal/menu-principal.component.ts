import { Component, Input, OnChanges, OnDestroy, OnInit, SimpleChanges, ViewEncapsulation } from '@angular/core';
import { MatDialog, MatDialogRef} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { LoginComponent } from 'src/app/components/usuario/login/login.component';
import { RegisterFormComponent } from 'src/app/components/usuario/register-form/register-form.component';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-menu-principal',
  templateUrl: './menu-principal.component.html',
  styleUrls: ['./menu-principal.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class MenuPrincipalComponent implements OnInit, OnDestroy{
  
  isInLogin!: Observable<boolean>;
  isUserAdmin$!: Observable<boolean>;
  loginSubscription!: Subscription| undefined;
  userLoguedSubscription!: Subscription ;
  imgPerfilSubscription!: Subscription ;
  userImgPerfil$!: Observable<string>;

  constructor(private readonly dialog:MatDialog,
              private authService:AuthService,
              private router:Router){}
 
  ngOnInit(): void {
    this.authService.hasLogued();
    this.isInLogin =this.authService.isInLogin();
    
    this.isUserAdmin$ = this.authService.isAdminOrMod();

    this.userImgPerfil$ = this.authService.getImgUserLogin();
  }

  ngOnDestroy(): void {
    this.loginSubscription!.unsubscribe();
    this.userLoguedSubscription.unsubscribe();
    this.imgPerfilSubscription.unsubscribe();
  }

  openLoginDialog(){
    let dialogRef = this.dialog.open(LoginComponent,{
      height:'auto',
      width:'auto',
      disableClose:true,
    })
  }

  openRegisterDialog(){
    let dialogRef = this.dialog.open(RegisterFormComponent,{
      height:'auto',
      width:'auto',
      disableClose:true,
      autoFocus:false,
    })
  }

  onRegister(){

  }
  logout(){
    this.authService.logout();
    this.router.navigate(['/'])
  }
}
