import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioRoutingModule } from './usuario-routing.module';
import { UsuarioComponent } from './usuario.component';
import { RegisterFormComponent } from './register-form/register-form.component';

import { AccountDetailsComponent } from './account-details/account-details.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CardDashboardModule } from 'src/app/shared/components/card-dashboard/card-dashboard.module';
import { RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
import { InputsModule } from 'src/app/shared/components/inputs/inputs.module';
import { LogoutComponent } from './logout/logout.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    UsuarioComponent,
    RegisterFormComponent,
    AccountDetailsComponent,
    ChangePasswordComponent,
    DashboardComponent,
    LoginComponent,
    EditProfileComponent,
    LogoutComponent
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    InputsModule,
    CardDashboardModule,
    MatDialogModule,
  ]
})
export class UsuarioModule { }
