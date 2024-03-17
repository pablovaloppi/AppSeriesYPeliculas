import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { ChangePaswordLogin } from '../../../core/models/changePasswordLogin';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MyValidators } from 'src/app/core/validators/my-validators';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  formPassword!: FormGroup;
  errorChangePassword: boolean = false;
  succesChangePassword:boolean = false;

  constructor(private readonly fb: FormBuilder,
    private readonly authService: AuthService,
    private readonly matSnackBar: MatSnackBar) {

  }
  ngOnInit(): void {
    this.formPassword = this.fb.group({
      password: ['', Validators.required],
      newPassword: ['', Validators.required],
    }, {
    })
  }

  onChangePassword() {
    let newPass: ChangePaswordLogin = {
      "userName": this.authService.getCurrentUserLogued()?.user!,
      "password": this.formPassword.value["password"],
      "newPassword": this.formPassword.value["newPassword"]
    };

    this.authService.changePassword(newPass).subscribe({
      next: () =>{
        this.errorChangePassword = false;
        this.succesChangePassword = false  ;
      },
      error: (error) =>{
        this.errorChangePassword = true;
        this.succesChangePassword = false;
        this.formPassword.reset();
      },
      complete: () => {
        //this.matSnackBar.open("Se ha actualizado correctamente la contraseña.", "X", { duration: 3000 });
        this.succesChangePassword = true;
        this.formPassword.reset();
      }
    })
  }


}
