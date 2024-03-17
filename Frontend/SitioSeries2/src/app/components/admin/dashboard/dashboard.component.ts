import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/core/services/category.service';
import { SerieService } from 'src/app/core/services/serie.service';
import { UserService } from 'src/app/core/services/user.service';
import { CardDashboardObject } from 'src/app/shared/utils/interfaces/card-dashboard-object';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  cardSeries?: CardDashboardObject;
  cardMovies?: CardDashboardObject;
  cardCategories?: CardDashboardObject;
  cardUsers?: CardDashboardObject;

  constructor(private readonly serieService: SerieService,
    private readonly categoryService: CategoryService,
    private readonly userService: UserService) {
  }

  ngOnInit(): void {
    this.setCardSerie();
    this.setCardCategory();
    this.setCardUser();
  }

  setCardSerie() {
    let card: CardDashboardObject
    this.serieService.getAllWithHeaders().subscribe(series => {
      card = {
        title: "Series Totales",
        count: JSON.parse(series.headers.get('X-Pagination')).TotalCount,
        linkText: "Ver Lista",
        color: "#75ada7",
        dirLink: "/admin/series/view"
      }
      this.cardSeries = { ...card };
    })
  }
  setCardUser() {
    let card: CardDashboardObject
    this.userService.getAllWithHeaders().subscribe(usuario => {
      card = {
        title: "Usiarios Totales",
        count: JSON.parse(usuario.headers.get('X-Pagination')).TotalCount,
        linkText: "Ver Lista",
        color: "#ab6510",
      }
      this.cardUsers = { ...card };
    })
  }

  setCardCategory() {
    let card: CardDashboardObject
    this.categoryService.getAllWithHeaders().subscribe(category => {
      card = {
        title: "Categorias Totales",
        count: JSON.parse(category.headers.get('X-Pagination')).TotalCount,
        linkText: "Ver Lista",
        color: "#ab1065"
      }
      this.cardCategories = { ...card };
    })
  }
}

