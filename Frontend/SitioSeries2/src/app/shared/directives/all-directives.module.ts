import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IsLoginDirective } from './is-login.directive';



@NgModule({
  declarations: [
    IsLoginDirective
  ],
  imports: [
    CommonModule
  ],
  exports:[
    IsLoginDirective,
  ]
})
export class AllDirectivesModule { }
