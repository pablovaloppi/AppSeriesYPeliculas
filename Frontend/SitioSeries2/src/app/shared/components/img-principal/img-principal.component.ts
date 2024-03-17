import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-img-principal',
  templateUrl: './img-principal.component.html',
  styleUrls: ['./img-principal.component.css']
})
export class ImgPrincipalComponent implements OnInit{
  @Input() title:string = 'Titulo';
  @Input() puntuacion:string = '9.6';
  @Input() cantidadEstrellas:number = 1;
  @Input() description:string = '';
  @Input() fehca:string ='';
  @Input() categoria:string ='default';
  @Input() img:string = '';
  @Input() linkButton:string = ''

  listEstrellas: number[] = [];
  constructor(){}
  ngOnInit(): void {
   this.setEstrellas();
  }

  setEstrellas(){
    if(this.cantidadEstrellas > 5){
      this.cantidadEstrellas = 5;
    }
    for (let i = 0; i < this.cantidadEstrellas; i++) {
      this.listEstrellas.push(1);
    }
  }
}
