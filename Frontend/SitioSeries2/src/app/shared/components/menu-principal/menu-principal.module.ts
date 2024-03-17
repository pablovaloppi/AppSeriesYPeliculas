import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuPrincipalComponent } from './menu-principal.component';

import {MatDialogModule} from '@angular/material/dialog';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import { AllDirectivesModule } from '../../directives/all-directives.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';


@NgModule({
  declarations: [
    MenuPrincipalComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatDialogModule,
    MatIconModule,
    MatMenuModule,
    AllDirectivesModule,
    MatSnackBarModule,
  ],
  exports:[
    MenuPrincipalComponent,
  ]
})
export class MenuPrincipalModule { }
