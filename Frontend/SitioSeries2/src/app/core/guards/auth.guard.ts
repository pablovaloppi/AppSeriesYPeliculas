import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  
  let authService = inject(AuthService);
  let router = inject(Router)
  let isLogued = false;

  authService.isInLogin().subscribe(value =>{
    if(value){
      isLogued = true;
      return isLogued;
    }
    else{
      router.navigateByUrl("usuario/login");
      return isLogued;
    }
  })  
  return isLogued;

};
