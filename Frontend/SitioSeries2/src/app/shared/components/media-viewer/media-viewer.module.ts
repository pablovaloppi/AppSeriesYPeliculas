import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MediaViewerComponent } from './media-viewer.component';
import { CardModule } from '../card/card.module';
import { RouterModule } from '@angular/router';
import { CategoryListModule } from '../category-list/category-list.module';



@NgModule({
  declarations: [
    MediaViewerComponent
  ],
  imports: [
    CommonModule,
    CardModule,
    RouterModule,
    CategoryListModule
  ],
  exports:[
    MediaViewerComponent
  ]
})
export class MediaViewerModule { }
