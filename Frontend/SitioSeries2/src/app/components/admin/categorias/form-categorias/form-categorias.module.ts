import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormCategoriasComponent } from './form-categorias.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormSeriesRoutingModule } from './form-categorias.routing.module';



@NgModule({
  declarations: [
    FormCategoriasComponent
  ],
  imports: [
    CommonModule,
    FormSeriesRoutingModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  exports:[
    FormCategoriasComponent
  ]
})
export class FormCategoriasModule { }
