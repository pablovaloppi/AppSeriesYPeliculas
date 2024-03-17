import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriasComponent } from './categorias.component';

const routes: Routes = [
  { path: '', redirectTo: 'view', pathMatch: 'full' },
  {
    path: '', component: CategoriasComponent, children: [
      { path: 'view', loadChildren: () => import('./view-list/view-list.module').then(m => m.ViewListModule) },
      { path: 'nueva-categoria', loadChildren: () => import('./form-categorias/form-categorias.module').then(m => m.FormCategoriasModule)}
]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriasRoutingModule { }
