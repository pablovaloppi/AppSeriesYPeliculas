import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ViewListComponent } from './view-list.component';
import { RouterModule } from '@angular/router';
import { ViewListRoutingModule } from './view-list-routing.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';



@NgModule({
  declarations: [
    ViewListComponent
  ],
  imports: [
    CommonModule,
    ViewListRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    MatSnackBarModule
  ],

})
export class ViewListModule { }
