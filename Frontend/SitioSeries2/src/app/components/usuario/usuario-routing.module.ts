import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioComponent } from './usuario.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { AccountDetailsComponent } from './account-details/account-details.component';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  {path:'', redirectTo:'dashboard', pathMatch:'full'},
  {path: '', component: UsuarioComponent, children:[
    {path: 'dashboard', component: DashboardComponent},
    {path: 'change-password', component: ChangePasswordComponent},
    {path: 'account-details', component: AccountDetailsComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioRoutingModule { }
