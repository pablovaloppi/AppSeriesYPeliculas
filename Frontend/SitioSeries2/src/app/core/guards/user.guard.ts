import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { AuthService } from '../services/auth.service';

export const userLoguedGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  authService.isInLogin().subscribe(value =>{
    if(value){
      //router.navigate(['usuario/account-details']);
      return false;  // Bloquea el acceso a login
    }
    else{
      return true;
    }
  }) 

  return true;
};
