import { AfterViewInit, ChangeDetectionStrategy, Component, OnInit, ViewChild } from '@angular/core';
import { Serie } from 'src/app/core/models/serie';
import { SerieService } from 'src/app/core/services/serie.service';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {MatPaginator, PageEvent} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { UserService } from 'src/app/core/services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
@Component({
  selector: 'app-view-list',
  templateUrl: './view-list.component.html',
  styleUrls: ['./view-list.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ViewListComponent implements OnInit{
  datasource!: MatTableDataSource<Serie>;
  serieList!: Serie[];
  columnsToDisplay = ['titulo', 'temporada', 'capitulo', 'anio', ];
  expandedElement!: Serie | null;
  private pageSizeInital = 5;
  private pageIndexInital = 1;
  pageSizeOptions = [5, 10, 25, 50];
  length = 0;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private readonly serieService:SerieService,
            private readonly userService:UserService,
            private matSnackBar:MatSnackBar,
            private router:Router){}

  ngOnInit(): void {
    
    this.serieService.getAllWithHeaders(this.pageIndexInital, this.pageSizeInital).subscribe(response =>{
      this.serieList = response.body;
      this.datasource = new MatTableDataSource(this.serieList );
      this.length = JSON.parse(response.headers.get('X-Pagination')).TotalCount;
      this.datasource.paginator = this.paginator;
      this.datasource.sort = this.sort;
    })
  } 

  handlePageEvent(e: PageEvent){
    console.log(`PageIndex: ${e.pageIndex + 1} PageSize: ${e.pageSize}`);
    this.serieService.getAllWithHeaders(e.pageIndex + 1, e.pageSize).subscribe(response=> {
      this.serieList = response.body;
      this.datasource = new MatTableDataSource(this.serieList );
      console.log(this.serieList);
      this.length = JSON.parse(response.headers.get('X-Pagination')).TotalCount;
      this.paginator.length = this.length;
      console.log(this.paginator.length);
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.datasource.filter = filterValue.trim().toLowerCase();

    if (this.datasource.paginator) {
      this.datasource.paginator.firstPage();
    }
  }

  onDelete(element:Serie){
    console.log(element);
    this.serieService.delete(element.id!).subscribe({
      next: () => { 
        this.matSnackBar.open(`La serie ${element.titulo} se ha eliminado`, "X", {duration:3000})
        this.serieList.pop();
        this.datasource = new MatTableDataSource(this.serieList );
        this.router.navigateByUrl("/admin/series")
      },
      error: (error) => { this.matSnackBar.open(`Ha ocurrido un error ${error}.`, "X", {duration:3000});}
    })
  }

}

