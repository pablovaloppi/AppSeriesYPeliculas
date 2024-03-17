import { Component, Input, OnInit } from '@angular/core';
import { Serie } from 'src/app/core/models/serie';
import { SerieService } from 'src/app/core/services/serie.service';

@Component({
  selector: 'app-carrousel',
  templateUrl: './carrousel.component.html',
  styleUrls: ['./carrousel.component.css']
})
export class CarrouselComponent implements OnInit {

  @Input() countList:number = 10;
  @Input() title:string = 'Titulo';
  @Input() linkVerMas:string = '';
  // Maximo 6 elementos
  listView: Serie[] = [];
  listSeries: Serie[] = [];
  positionInitial: number = 0;
  positionFinal: number = 5; // Maximo sino sale de la pantalla

  constructor(private readonly serieService: SerieService) {

  }

  ngOnInit(): void {
    this.serieService.getAll(1, this.countList).subscribe(serie => {
      this.listSeries = serie;
      this.setListView(serie);
    })
  }
  
  setListView(listTotal: Serie[]) {

    if (listTotal.length != 0) {
      for (let i = this.positionInitial; i <= this.positionFinal; i++) {
        this.listView[i] = listTotal[i];
      }
    }
  }

  next() {
    //Agrega al final del la lista(push) el elemento de la primer posicion(shift)
    this.listSeries.push(this.listSeries.shift()!);
    this.setListView(this.listSeries);
  }

  previous() {
    //Agrega al principio del la lista(unshift) el elemento de la ultima posicion(pop)
    this.listSeries.unshift(this.listSeries.pop()!);
    this.setListView(this.listSeries);
  }
}
