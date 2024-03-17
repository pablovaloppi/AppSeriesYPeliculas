import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { UserService } from '../services/user.service';
import { AuthService } from '../services/auth.service';

export const userGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);
  let isLogin = false;

  isLogin = authService.hasLogued();
  // userService.isLogin().subscribe(login =>{ 
  //   isLogin = login
  //   console.log(login);
  // });

  // if(!isLogin){
  //   router.navigateByUrl('home');
  // }

  return isLogin;
};
