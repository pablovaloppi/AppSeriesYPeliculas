import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { switchMap } from 'rxjs';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { ActualUserRouteService } from 'src/app/core/services/component-comunication/actual-user-route.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css'],
})
export class EditProfileComponent implements OnInit {
  formEdit!: FormGroup;
  userLogued?: User;
  idUsuario!:number;

  errorDetails: boolean = false;
  succesDetails: boolean = false;

  private _formBuilder = inject(FormBuilder);
  private _userService = inject(UserService);
  private _authService = inject(AuthService);
  private _actualUserRoute = inject(ActualUserRouteService)

  ngOnInit(): void {
    this.idUsuario = this._authService.getCurrentIdLogued();

    this.formEdit = this._formBuilder.group({
      nombre: new FormControl(''),
      apellido: new FormControl(''),
      email: new FormControl(''),
      edad: new FormControl(''),
      direccion: new FormControl(''),
    });
    this._userService
      .getById(this.idUsuario)
      .subscribe((value) => {
        this.userLogued = value;
      });

      this._actualUserRoute.setTitleRoute("Edit Profile")
      this._actualUserRoute.setBackRoute("/usuario")
  }

  
  onUpdate() {
    let usuario: User;
    this._userService.getById(this.idUsuario).pipe(
      switchMap(val => {
        usuario = { 'idUsuario': val.idUsuario, ...this.formEdit.value, 'imgPerfil': val.imgPerfil }
        return this._userService.update(usuario, this.idUsuario)
      })
    ).subscribe({
      next: () => {
        this.errorDetails = false;
        this.succesDetails = false;
      },
      error: (error) => {
        this.errorDetails = true;
      },
      complete: () => {
        this.errorDetails = false;
        this.succesDetails = true;
      }
    })

  }

  get nameControl(): FormControl {
    return this.formEdit.controls['nombre'] as FormControl;
  }
  get lastnameControl(): FormControl {
    return this.formEdit.controls['apellido'] as FormControl;
  }
  get emailControl(): FormControl {
    return this.formEdit.controls['email'] as FormControl;
  }
  get ageControl(): FormControl {
    return this.formEdit.controls['edad'] as FormControl;
  }
  get addresControl(): FormControl {
    return this.formEdit.controls['direccion'] as FormControl;
  }
}
