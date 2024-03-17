import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComentarioComponent } from './comentario.component';



@NgModule({
  declarations: [
    ComentarioComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    ComentarioComponent
  ]
})
export class ComentarioModule { }
