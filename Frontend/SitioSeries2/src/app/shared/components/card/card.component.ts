import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent {
   @Input() title:string = 'title';
   @Input() img:string = '';
   @Input()  puntuacion:number = 0;
}
