import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SeriesAdminRoutingModule } from './series-admin-routing.module';
import { SeriesAdminComponent } from './series-admin.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    SeriesAdminComponent,
  ],
  imports: [
    CommonModule,
    SeriesAdminRoutingModule,
    RouterModule
  ]
})
export class SeriesAdminModule { }
