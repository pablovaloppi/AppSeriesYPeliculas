import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, Subject, concatMap, mergeMap, switchMap } from 'rxjs';
import { User } from 'src/app/core/models/user';
import { UserUpdate } from 'src/app/core/models/userUpdate';
import { AuthService } from 'src/app/core/services/auth.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-account-details',
  templateUrl: './account-details.component.html',
  styleUrls: ['./account-details.component.css']
})
export class AccountDetailsComponent implements OnInit {
  detailsForm!: FormGroup;
  idUsuario!: number;
  errorDetails: boolean = false;
  succesDetails: boolean = false;
  constructor(private readonly fb: FormBuilder,
    private readonly authService: AuthService,
    private readonly userService: UserService) {

  }


  ngOnInit(): void {
    this.detailsForm = this.fb.group({
      nombre: ['', [Validators.required]],
      apellido: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      edad: ['', [Validators.required]],
      direccion: ['', [Validators.required]],
    })
    this.idUsuario = this.authService.getCurrentUserLogued()?.id!;
    this.userService.getById(this.idUsuario).subscribe(user => {
      this.detailsForm.patchValue(user);
    })
  }

  onUpdate() {
    let usuario: User;
    this.userService.getById(this.idUsuario).pipe(
      switchMap(val => {
        usuario = { 'idUsuario': val.idUsuario, ...this.detailsForm.value, 'imgPerfil': val.imgPerfil }
        return this.userService.update(usuario, this.idUsuario)
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

  //   this.userService.getById(this.idUsuario).subscribe(user=>{
  //     let usuario:User = {'idUsuario': user.idUsuario , ...this.detailsForm.value, 'imgPerfil': user.imgPerfil};
  //     this.userService.update(usuario, this.idUsuario).subscribe({
  //       next: ()=>{
  //         this.errorDetails = false;
  //         this.succesDetails = false;
  //       },
  //       error: (error)=>{
  //         this.errorDetails = true;
  //       },
  //       complete:() =>{
  //         this.errorDetails = false;
  //         this.succesDetails = true;
  //       }
  //     })
  //   })
}
}
