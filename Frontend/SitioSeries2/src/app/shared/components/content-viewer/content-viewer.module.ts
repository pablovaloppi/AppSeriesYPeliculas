import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentViewerComponent } from './content-viewer.component';
import { CardModule } from '../card/card.module';



@NgModule({
  declarations: [
    ContentViewerComponent,
  ],
  imports: [
    CommonModule,
    CardModule
  ]
})
export class ContentViewerModule { }
