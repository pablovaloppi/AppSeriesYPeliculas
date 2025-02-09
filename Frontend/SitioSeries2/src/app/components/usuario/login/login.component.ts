import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/core/models/login';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginGroup!: FormGroup;
  islogin!: User;
  isConnected: boolean = true;
  error:boolean = false;

  constructor(private readonly fb: FormBuilder,
    private readonly authService: AuthService,
    private readonly router: Router
  ) {

  }

  ngOnInit(): void {
    // this.loginGroup = this.fb.group({
    //   username: ['', [Validators.required]],
    //   password: ['', Validators.required],
    // });

    this.loginGroup = new FormGroup({
      username: new FormControl(''),
      password: new FormControl(''),
    })
  }
  get usernameControl(): FormControl {
    return this.loginGroup.get('username') as FormControl;
  }

  get passwordControl(): FormControl {
    return this.loginGroup.get('password') as FormControl;
  }


  onLogin() {
    let login: Login = { username: this.loginGroup.value['username'], password: this.loginGroup.value['password'] };
    this.error = false;
    this.isConnected = false;
    console.log(login);

      this.authService.login(login).subscribe({
        next: resp => {
          console.log(resp);
          this.authService.saveLoginInLocalStorage(resp.usuario, resp.token);
          this.router.navigateByUrl("/usuario");
        },
        error: (error) =>{
          this.error = true;
          this.isConnected = true;
        },
        complete: () =>{
          this.isConnected = true;
        }
      })
    }
    
  }


