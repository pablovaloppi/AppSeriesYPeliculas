import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { SerieFavoritaService } from 'src/app/core/services/serie-favorita.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  seriesFavoritasCount:number = 0;
  constructor(private readonly seriesFavoritaService:SerieFavoritaService,
    private readonly authService:AuthService) {
        
  }
  ngOnInit(): void {
    this.obtenerCantidadSeriesFavoritas();
  }

  private obtenerCantidadSeriesFavoritas(){
    this.seriesFavoritaService.getCountSerieFavorita(this.authService.getCurrentIdLogued()).subscribe(sf => {
      this.seriesFavoritasCount = sf;
    })
  }
}
