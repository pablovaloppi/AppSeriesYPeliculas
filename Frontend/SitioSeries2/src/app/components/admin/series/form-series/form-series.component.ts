import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Category } from 'src/app/core/models/category';
import { Pais } from 'src/app/core/models/pais';
import { Serie } from 'src/app/core/models/serie';
import { AuthService } from 'src/app/core/services/auth.service';
import { CategoryService } from 'src/app/core/services/category.service';
import { PaisService } from 'src/app/core/services/pais.service';
import { SerieService } from 'src/app/core/services/serie.service';
import { MyValidators } from 'src/app/core/validators/my-validators';
import { InputValidation } from 'src/app/shared/utils/input-validation';

@Component({
  selector: 'app-form-series',
  templateUrl: './form-series.component.html',
  styleUrls: ['./form-series.component.css']
})
export class FormSeriesComponent extends InputValidation implements OnInit {
  formSerie!: FormGroup;
  paises: Pais[] = [];
  categorias: Category[] = [];
  isEdit:boolean = false;
  id?:number;

  constructor(private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private readonly router:Router,
    private readonly activatedRoute: ActivatedRoute,
    private readonly paisService: PaisService,
    private readonly categoryService: CategoryService,
    private readonly serieService: SerieService,
    private readonly authService: AuthService) {
    super()
  }
  ngOnInit(): void {

    this.formSerie = this.fb.group({
      titulo: ['', [Validators.required]],
      descripcion: ['', [Validators.required]],
      categoriaId: ['', [Validators.required]],
      imgPortada: ['', [Validators.required]],
      anio: ['', [Validators.required, MyValidators.isInRange(1900, new Date().getUTCFullYear())]],
      paisId: ['', [Validators.required]],
      duracion: ['', [Validators.required]],
      temporada: ['', [Validators.required]],
      capitulo: ['', [Validators.required]],
      link: ['', [Validators.required]],
    })
    this.setFormGroup(this.formSerie);
    this.id = this.activatedRoute.snapshot.params['id']
    if(this.id !== undefined){
      this.isEdit = true;

      this.serieService.getById(this.activatedRoute.snapshot.params['id']).subscribe( serie=>{
        this.formSerie.patchValue(serie);
      })
    }

    this.categoryService.getAll().subscribe(categorias => {
      this.categorias = categorias;
    })

    this.paisService.getAll().subscribe(paises => {
      this.paises = paises;
    })
  }

  onNewOrEditSerie() {
    let serie = { ...this.formSerie.value, usuarioId: this.authService.getCurrentUserLogued()?.id };
    
    if(this.id !== undefined){
      console.log("Entro");
      this.editSerie(serie);
    }
    else{
      console.log("aca");
      this.newSerie(serie);
    }
  }

  newSerie(serie: Serie){
    this.serieService.create(serie).subscribe(
      {
        error: (error:HttpErrorResponse) => {
          console.log(error);
          this.snackBar.open(`${error.error}`, 'X', {duration:3000});
        },
        complete: () => {
          this.snackBar.open(`La serie ${serie.titulo} se ha creado con exito`, 'X', { duration: 3000 })
          this.router.navigate(["admin/series/view"]);
        }
      }
    )
  }

  editSerie(serie: Serie){
    console.log(serie);
    this.serieService.edit(this.id!, serie).subscribe({
      error: (error) => {
        console.log(error);
        this.snackBar.open(`Ha occurrido un error, intenta nuevamente.`, "X", {duration:3000});
      },
      complete: ()=> {
        this.snackBar.open(`La serie ${serie.titulo} se ha actualizado correctamente.`, "X", {duration:3000});
        this.router.navigate(["admin/series/view"]);
      }

    })
  }

}
