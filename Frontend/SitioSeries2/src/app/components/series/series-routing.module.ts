import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SeriesComponent } from './page/series.component';
import { ViewSerieComponent } from './page/view-serie/view-serie.component';

const routes: Routes = [
  {path:'', component:SeriesComponent},
  {path:':id', component:ViewSerieComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SeriesRoutingModule { }
