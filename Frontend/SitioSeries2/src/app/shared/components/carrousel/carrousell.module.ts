import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardModule } from '../card/card.module';
import { MatIconModule } from '@angular/material/icon';
import { CarrouselComponent } from './carrousel.component';
import { CardComponent } from 'src/app/shared/components/card/card.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CarrouselComponent,
  ],
  imports: [
    CommonModule,
    MatIconModule,
    CardModule,
    RouterModule,
  ],
  exports:[
    CarrouselComponent
  ]
})
export class CarrousellModule { }
