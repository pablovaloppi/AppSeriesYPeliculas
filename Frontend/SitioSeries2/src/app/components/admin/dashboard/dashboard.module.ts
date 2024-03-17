import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { CardDashboardComponent } from 'src/app/shared/components/card-dashboard/card-dashboard.component';
import { CardDashboardModule } from 'src/app/shared/components/card-dashboard/card-dashboard.module';


@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    CardDashboardModule,
  ],  
})
export class DashboardModule { }
