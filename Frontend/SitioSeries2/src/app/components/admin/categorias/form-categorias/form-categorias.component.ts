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
  selector: 'app-form-categorias',
  templateUrl: './form-categorias.component.html',
  styleUrls: ['./form-categorias.component.css']
})
export class FormCategoriasComponent extends InputValidation implements OnInit {
  formCategoria!: FormGroup;
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

    this.formCategoria = this.fb.group({
      nombre: ['', [Validators.required]],
    })

    this.setFormGroup(this.formCategoria);

    this.id = this.activatedRoute.snapshot.params['id']

    if(this.id !== undefined){
      this.isEdit = true;
    }
  }

  onNewOrEditSerie() {
    let nuevaCategoria:Category = { id: -1, nombre: this.formCategoria.value['nombre']};
    
    if(this.id !== undefined){
      console.log("Entro");
      this.editSerie(nuevaCategoria);
    }
    else{
      console.log("aca");
      this.newCategory(nuevaCategoria);
    }
  }

  newCategory(nuevaCategoria: Category){
    console.log(nuevaCategoria);
    this.categoryService.create(nuevaCategoria).subscribe(
      {
        error: (error:HttpErrorResponse) => {
          console.log(error);
          this.snackBar.open(`${error.error}`, 'X', {duration:3000});
        },
        complete: () => {
          this.snackBar.open(`La categoria ${nuevaCategoria.nombre} se ha creado con exito`, 'X', { duration: 3000 })
          this.router.navigate(["admin/categorias/view"]);
        }
      }
    )
  }

  editSerie(nuevaCategoria: Category){
    console.log(nuevaCategoria);
    // this.cate.edit(this.id!, serie).subscribe({
    //   error: (error) => {
    //     console.log(error);
    //     this.snackBar.open(`Ha occurrido un error, intenta nuevamente.`, "X", {duration:3000});
    //   },
    //   complete: ()=> {
    //     this.snackBar.open(`La serie ${serie.titulo} se ha actualizado correctamente.`, "X", {duration:3000});
    //     this.router.navigate(["admin/series/view"]);
    //   }

    // })
  }

}
