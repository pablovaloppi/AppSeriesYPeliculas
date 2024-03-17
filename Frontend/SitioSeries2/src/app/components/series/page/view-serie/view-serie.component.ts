import { Component, OnInit } from '@angular/core';
import { Serie } from 'src/app/core/models/serie';
import { SerieService } from '../../../../core/services/serie.service';
import { ActivatedRoute, Params } from '@angular/router';
import { CategoryService } from 'src/app/core/services/category.service';
import { Category } from 'src/app/core/models/category';
import { BehaviorSubject, Observable } from 'rxjs';
import { SerieFavoritaService } from 'src/app/core/services/serie-favorita.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { SerieFavorita } from 'src/app/core/models/serieFavorita';
import { Comentario } from 'src/app/core/models/comentario';
import { ComentarioService } from '../../../../core/services/comentario.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-view-serie',
  templateUrl: './view-serie.component.html',
  styleUrls: ['./view-serie.component.css']
})
export class ViewSerieComponent implements OnInit {

  serie?: Serie;
  id!: number;
  category!: Category;
  serieFavorita!: SerieFavorita;
  favorita$ = new BehaviorSubject(false);
  
  listaComentarios: Comentario[] = [];
  listaComentarios$!: Observable<Comentario[]>
  formComentario!: FormGroup;

  constructor(private readonly serieService: SerieService,
    private readonly categoryService: CategoryService,
    private readonly authService: AuthService,
    private readonly serieFavoritaService: SerieFavoritaService,
    private readonly activeRoute: ActivatedRoute,
    private readonly comentarioService:ComentarioService,
    private readonly formBuilder:FormBuilder) {

  }
  ngOnInit(): void {
    this.activeRoute.params.subscribe((param: Params) => {
      this.id = param['id'];
    })

    this.serieService.getById(this.id).subscribe(s => {
      this.serie = s;
    })

    this.serieFavoritaService.getSerieFavorita(this.authService.getCurrentIdLogued(), this.id).subscribe(s => {
      if (s !== null) {
        
        this.favorita$.next(true);
        console.log(this.favorita$.value);
      }
    })

    this.obtenerComentarios();

    this.formComentario = this.formBuilder.group(
      {
        contenido: ['', [Validators.required]],
      }
    )
  }
  onFavorito() {
    this.serieFavorita = { serieId: this.id, usuarioId: this.authService.getCurrentIdLogued() };

    if (this.favorita$.value) {
      this.quitarFavorito(this.serieFavorita);
    }
    else{
      this.agregarFavorito(this.serieFavorita);
    }
  }

  private agregarFavorito(serieFavorita:SerieFavorita){
    this.serieFavoritaService.agregar(this.serieFavorita).subscribe(() => {
      this.favorita$.next(true);    
    }) 
  }

  private quitarFavorito(serieFavorita:SerieFavorita){
    this.serieFavoritaService.quitar(this.serieFavorita).subscribe(() => {
      this.favorita$.next(false);
    })
  }
  obtenerComentarios(){
    this.comentarioService.obtener(this.id).subscribe(comentarios =>{
      this.listaComentarios = comentarios;
    })

  }

  onAgregarComentario(){
    this.comentarioService.agregar({contenido: this.formComentario.value.contenido
      , serieId:this.id, usuarioId:this.authService.getCurrentIdLogued(),
    imagenUser: this.authService.getImagenUserLogued(), nombreUsuario: this.authService.getUserNameLogued()})
    .subscribe(comentario => {
      this.listaComentarios.push(comentario);
      console.log(comentario);
    })
  }
}
