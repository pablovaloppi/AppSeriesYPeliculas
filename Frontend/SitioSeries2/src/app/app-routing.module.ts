import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { userGuard } from './core/guards/user.guard';
import { AdminModule } from './components/admin/admin.module';
import { adminGuard } from './core/guards/admin.guard';
import { LoginComponent } from './components/usuario/login/login.component';

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'recientes', loadChildren: () => import('./components/recientes/recientes.module').then(m => m.RecientesModule)},
  {path: 'series', loadChildren: () => import('./components/series/series.module').then(m => m.SeriesModule)},
  {path: 'peliculas', loadChildren: () => import('./components/peliculas/peliculas.module').then(m => m.PeliculasModule)},
  {path: 'usuario', loadChildren: () => import('./components/usuario/usuario.module').then(m => m.UsuarioModule),canActivate:[userGuard]},
  {path: 'admin', loadChildren: () => import('./components/admin/admin.module').then(m => m.AdminModule), canActivate:[adminGuard]},
  { path: '**', redirectTo: '/home', pathMatch: 'full'},
  { path: '', redirectTo: '/home', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
