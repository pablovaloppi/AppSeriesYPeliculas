import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { UserService } from '../services/user.service';
import { UserType } from '../models/user';
import { AuthService } from '../services/auth.service';

export const adminGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  let isAdminOrModerator = false;
   
  isAdminOrModerator = authService.getCurrentUserLogued()?.tipoUsuarioId === UserType.ADMINISTRATOR || 
    authService.getCurrentUserLogued()?.tipoUsuarioId === UserType.MODERATOR
  
  return isAdminOrModerator;
  return true;
};
