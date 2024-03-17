import { AfterViewInit, Component, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs';
import { Category } from 'src/app/core/models/category';
import { Serie } from 'src/app/core/models/serie';
import { CategoryService } from 'src/app/core/services/category.service';
import { SerieService } from 'src/app/core/services/serie.service';

@Component({
  selector: 'app-series',
  templateUrl: './series.component.html',
  styleUrls: ['./series.component.css'],
  encapsulation: ViewEncapsulation.None, // Sirve para poder sobreescribir los estilos de angular material
})
export class SeriesComponent implements OnInit, OnDestroy{
  categories: Category[] = [];
  categorySelected:string = '';
  serieList: Serie[] = [];

  subcriptionList? : Subscription;
  @Input() test:number = 0;

  constructor( private readonly categoryService: CategoryService,
               private readonly serieService: SerieService){

  }

  ngOnDestroy(): void {
    this.subcriptionList?.unsubscribe();
  }

  ngOnInit(): void {

    this.categoryService.getAll().subscribe({
      next: cat => this.categories = cat,
    })
  }

  getIdByName(name:string):number {
    console.log(name);
    return this.categories.find(cat => cat.nombre === name)!.id!;
  }
  selectedTabValue(event:any){
    this.categorySelected = event.tab.textLabel;
    this.serieService.getAllByCategory( this.getIdByName(this.categorySelected)).subscribe( serie =>{
      this.serieList = serie;
    })
  }


}
