import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioComponent } from './usuario.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { authGuard } from 'src/app/core/guards/auth.guard';
import { userLoguedGuard } from 'src/app/core/guards/user.guard';
import { EditProfileComponent } from './edit-profile/edit-profile.component';

const routes: Routes = [
 {path: '', redirectTo:'account-details', pathMatch:'full'},
  {path: '', component: UsuarioComponent, children:[
    {path: 'login', component: LoginComponent,canActivate:[userLoguedGuard]},
    {path: 'register', component: RegisterFormComponent},
    {path: 'dashboard', component: DashboardComponent, canActivate:[authGuard]},
    {path: 'change-password', component: ChangePasswordComponent, canActivate:[authGuard]},
    {path: 'account-details', component: AccountDetailsComponent, canActivate:[authGuard]},
    {path: 'edit-profile', component:EditProfileComponent, canActivate:[authGuard]}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioRoutingModule { }
