import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecientesComponent } from './recientes.component';

const routes: Routes = [
  {path:'', component:RecientesComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecientesRoutingModule { }
