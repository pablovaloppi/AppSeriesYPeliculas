import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Login } from 'src/app/core/models/login';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, MatIconModule, MatTooltipModule, CommonModule, MatProgressSpinnerModule,]
})
export class LoginComponent implements OnInit {
  loginGroup!: FormGroup;
  islogin!: User;
  isConnected: boolean = true;
  error:boolean = false;

  constructor(private readonly fb: FormBuilder,
    private readonly authService: AuthService,
    private dialogRef: MatDialogRef<LoginComponent>,
  ) {

  }

  ngOnInit(): void {
    this.loginGroup = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', Validators.required],
    });
  }

  onLogin() {
    let login: Login = { username: this.loginGroup.value['username'], password: this.loginGroup.value['password'] };
    this.error = false;
    this.isConnected = false;
    // El setTimeout no es necesario, solamente esta para ver el spinner al momento de logear
    setTimeout(() => {
      this.authService.login(login).subscribe({
        next: resp => {
          
          this.authService.saveLoginInLocalStorage(resp.usuario, resp.token);
          this.close();
        },
        error: (error) =>{
          this.error = true;
          this.isConnected = true;
        },
        complete: () =>{
          this.isConnected = true;
        }
      })
    }, 2000);
    
  }

  close() {
    
    this.dialogRef.close();
  }

}
