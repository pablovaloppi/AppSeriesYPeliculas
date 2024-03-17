import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { FormSeriesComponent } from './series/form-series/form-series.component';

const routes: Routes = [
  {path: '', redirectTo: 'dashboard', pathMatch:'full'},
  {path:'', component:AdminComponent, children: [  
    {path:'series', loadChildren: () => import('../admin/series/series-admin.module').then(m => m.SeriesAdminModule)},
    {path:'dashboard', loadChildren: () => import('../admin/dashboard/dashboard.module').then(m => m.DashboardModule)},
    {path:'categorias', loadChildren: () => import('../admin/categorias/categorias.module').then(m => m.CategoriasModule)}
    
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
