import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentViewerComponent } from './content-viewer.component';
import { CardModule } from '../card/card.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    ContentViewerComponent,
  ],
  imports: [
    CommonModule,
    CardModule,
    RouterModule
  ],
  exports:[
    ContentViewerComponent
  ]
})
export class ContentViewerModule { }
