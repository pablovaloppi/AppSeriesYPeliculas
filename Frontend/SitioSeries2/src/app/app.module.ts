import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatIconModule} from '@angular/material/icon';
import { CarrousellModule } from './shared/components/carrousel/carrousell.module';
import { MenuPrincipalModule } from './shared/components/menu-principal/menu-principal.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ImgPrincipalComponent } from './shared/components/img-principal/img-principal.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { PetitionInterceptor } from './core/interceptors/petition.interceptor';
import { CardDashboardComponent } from './shared/components/card-dashboard/card-dashboard.component';
import { ComentarioComponent } from './shared/components/comentario/comentario.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ImgPrincipalComponent,
    FooterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MenuPrincipalModule,
    CarrousellModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: PetitionInterceptor,
      multi:true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
