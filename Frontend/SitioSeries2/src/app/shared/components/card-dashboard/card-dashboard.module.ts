import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardDashboardComponent } from './card-dashboard.component';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CardDashboardComponent,
  ],
  imports: [
    CommonModule,
    MatIconModule,
    RouterModule
  ],
  exports:[
    CardDashboardComponent,
  ]
})
export class CardDashboardModule { }
