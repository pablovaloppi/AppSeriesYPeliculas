import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from 'src/app/core/models/category';
import { CategoryService } from 'src/app/core/services/category.service';
import { SerieService } from 'src/app/core/services/serie.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  @Output() selectedCategory:EventEmitter<number> = new EventEmitter();


  selectedCategoryID: number | null = null;
  categoryList:Category[] = [];
  constructor(private readonly _categoryService : CategoryService, private readonly _serieService:SerieService){

  }

  ngOnInit(): void {
    this._categoryService.getAll().subscribe(values =>{
      this.categoryList = values;
      this.selectCategory(this.categoryList[0].id);

    })
  }

  selectCategory(categoryId:number){
    this.selectedCategoryID = categoryId;
    this.selectedCategory.emit(categoryId);
  }

}
