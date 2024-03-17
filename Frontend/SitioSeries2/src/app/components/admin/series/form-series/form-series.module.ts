import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormSeriesComponent } from './form-series.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormSeriesRoutingModule } from './form-series-routing.module';



@NgModule({
  declarations: [
    FormSeriesComponent
  ],
  imports: [
    CommonModule,
    FormSeriesRoutingModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  exports:[
    FormSeriesComponent
  ]
})
export class FormSeriesModule { }
