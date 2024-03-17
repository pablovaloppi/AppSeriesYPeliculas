import { ChangeDetectionStrategy, Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Pais } from 'src/app/core/models/pais';
import { UserCration } from 'src/app/core/models/userCreation';
import { PaisService } from 'src/app/core/services/pais.service';
import { UserService } from 'src/app/core/services/user.service';
import { InputValidation } from 'src/app/shared/utils/input-validation';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css'],
})
export class RegisterFormComponent implements OnInit {

  registerForm!: FormGroup;
  isComplete:boolean = true;
  paises:Pais[] = [];

  constructor(private readonly fb: FormBuilder,
    private readonly userService: UserService,
    private readonly paisService: PaisService,
    private snackBar: MatSnackBar,
    private readonly router: Router,
    private diologRef: MatDialogRef<RegisterFormComponent>,
    ) { 
    }

  ngOnInit(): void {
    this.paisService.getAll().subscribe( paises =>{
      this.paises = paises;
      console.log(paises);
    })

    this.registerForm = this.fb.group({
      usuario: ['', [Validators.required, Validators.minLength(5)]],
      password: ['', [Validators.required,]],
      nombre: ['', [Validators.required]],
      apellido: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      edad: ['', [Validators.required]],
      direccion: ['', [Validators.required]],
      pais: ['', [Validators.required]],
      terms: [false, [Validators.requiredTrue]],
    })
  }

  onRegister() {
    let userCreation: UserCration = {
      user: this.registerForm.get('usuario')?.value,
      password: this.registerForm.get('password')?.value,
      nombre: this.registerForm.get('nombre')?.value,
      apellido: this.registerForm.get('apellido')?.value,
      email: this.registerForm.get('email')?.value,
      edad: Number(this.registerForm.get('edad')?.value),
      paisId: Number(this.registerForm.get('pais')?.value),
      direccion: this.registerForm.get('direccion')?.value,
      imgPerfil: "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png"
    }
    console.log(userCreation);
    this.isComplete = false;
    this.userService.create(userCreation).subscribe({
      next: user => { this.router.navigate(['home']) },
      error: (error) => {
         this.snackBar.open("A ocurrido un error, intenta nuevamente.", 'X', { duration: 3000 });
         this.isComplete = true;  

      },
      complete: () => {
        this.isComplete = true;
        this.snackBar.open("Se ha registrado correctamente.", 'X', { duration: 3000 });
        this.closeWindow();
      }
    })

  }

  closeWindow() {
    this.diologRef.close();
  }
 
}
