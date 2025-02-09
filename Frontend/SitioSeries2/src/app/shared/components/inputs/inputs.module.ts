import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputTextComponent } from './input-text/input-text.component';
import { InputCheckboxComponent } from './input-checkbox/input-checkbox.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MainButtonComponent } from './main-button/main-button.component';



@NgModule({
  declarations: [
    InputTextComponent,
    InputCheckboxComponent,
    MainButtonComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    InputTextComponent,
    InputCheckboxComponent,
    MainButtonComponent

  ]
})
export class InputsModule { }
