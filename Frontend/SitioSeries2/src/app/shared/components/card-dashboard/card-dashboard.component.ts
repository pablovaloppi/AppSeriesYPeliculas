import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-dashboard',
  templateUrl: './card-dashboard.component.html',
  styleUrls: ['./card-dashboard.component.css']
})
export class CardDashboardComponent implements OnInit {

  @Input() title?:string = 'Title';
  @Input() count?:string = "10";
  @Input() linkText?:string = "Link";
  @Input() backgroundColor?:string = '#d6d6d6b7';
  @Input() dirLink?:string = '';
  ngOnInit(): void {
    console.log("Se cargo la card Dashboard");
  }
}
