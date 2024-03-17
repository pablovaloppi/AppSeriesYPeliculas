import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SeriesComponent} from './page/series.component';
import { SeriesRoutingModule } from './series-routing.module';

import { MatTabsModule } from '@angular/material/tabs'
import { ContentViewerComponent } from 'src/app/shared/components/content-viewer/content-viewer.component';
import { CardModule } from 'src/app/shared/components/card/card.module';
import { ViewSerieComponent } from './page/view-serie/view-serie.component';
import { MatIconModule } from '@angular/material/icon';
import { ComentarioModule } from 'src/app/shared/components/comentario/comentario.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    SeriesComponent,
    ContentViewerComponent,
    ViewSerieComponent,
  ],
  imports: [
    CommonModule,
    SeriesRoutingModule,
    MatTabsModule,
    MatIconModule,
    CardModule,
    ComentarioModule,
    ReactiveFormsModule, 
  ]
})
export class SeriesModule { }
