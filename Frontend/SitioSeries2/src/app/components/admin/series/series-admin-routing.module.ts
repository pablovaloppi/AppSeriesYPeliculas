import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewListComponent } from './view-list/view-list.component';
import { FormSeriesComponent } from './form-series/form-series.component';
import { SeriesAdminComponent } from './series-admin.component';

const routes: Routes = [
  {path:'', redirectTo: 'view', pathMatch:'full'},
  {path:'', component:SeriesAdminComponent, children: [
    {path:'view', loadChildren: () => import('./view-list/view-list.module').then(m => m.ViewListModule)},
    {path:'nueva-serie', loadChildren: () => import('./form-series/form-series.module').then( m => m.FormSeriesModule)},
    {path:'editar-serie/:id', component:FormSeriesComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SeriesAdminRoutingModule { }
