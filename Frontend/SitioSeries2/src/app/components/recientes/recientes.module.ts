import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RecientesRoutingModule } from './recientes-routing.module';
import { RecientesComponent } from './recientes.component';


@NgModule({
  declarations: [
    RecientesComponent
  ],
  imports: [
    CommonModule,
    RecientesRoutingModule
  ]
})
export class RecientesModule { }
