import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { Serie } from 'src/app/core/models/serie';
import { SerieService } from 'src/app/core/services/serie.service';

@Component({
  selector: 'app-media-viewer',
  templateUrl: './media-viewer.component.html',
  styleUrls: ['./media-viewer.component.css']
})
export class MediaViewerComponent implements OnInit,  AfterViewInit {
  @Input() countList:number = 10;
  @Input() title:string = 'Titulo';
  @Input() linkVerMas:string = '';
  @Input() trending :boolean = false;
  @Input() showCategories:boolean = true;

  // Maximo 6 elementos
  listView: Serie[] = [];
  listSeries: Serie[] = [];
  positionInitial: number = 0;
  positionFinal: number = 5; // Maximo sino sale de la pantalla

  @ViewChild('listItem', { static: false }) listItem!: ElementRef;
  scrollSpeed = 1; // Velocidad del scroll
  animationFrame: any;

  sizeCardAndGap:number = 258;

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


  ngAfterViewInit() {
    if(window.innerWidth > 768)
       this.startScrolling();
  }

  mouseOver(){
    this.scrollSpeed = 0;
  }
  mouseOut(){
    this.scrollSpeed = 1;
  }
  startScrolling() {
    const list = this.listItem.nativeElement;

    const scroll = () => {
      if (list.scrollLeft >= this.sizeCardAndGap) {
        list.scrollLeft = 0; // Reinicia el scroll cuando llega al final
        this.next();
      } else {
        list.scrollLeft += this.scrollSpeed; // Mueve el scroll
      }
      this.animationFrame = requestAnimationFrame(scroll);
    };

    this.animationFrame = requestAnimationFrame(scroll);
  }

}
