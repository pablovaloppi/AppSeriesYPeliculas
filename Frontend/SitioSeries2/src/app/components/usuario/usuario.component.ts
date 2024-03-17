import { HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { ChangeDetectorRef, Component, EventEmitter, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { UploadService } from 'src/app/core/services/upload.service';
import { UserService } from 'src/app/core/services/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css'],
})
export class UsuarioComponent implements OnInit {

  isInLogin!: Observable<boolean>;
  userLoguedId!: number;
  userImgPerfil$!: Observable<string>;
  constructor(private authService: AuthService,
    private readonly router: Router,
    private readonly uploadService: UploadService,
    private readonly userService: UserService,) {

  }
  ngOnInit(): void {
    this.userLoguedId = this.authService.getCurrentUserLogued()?.id!;
    this.isInLogin = this.authService.isInLogin();
    this.userImgPerfil$ = this.authService.getImgUserLogin();
  }

  onLogout() {
    this.authService.logout();
    this.router.navigateByUrl("/home");

  }

  uploadFile(file: any) {
    if (file.lenght === 0) {
      return;
    }
    let fileToUpload = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    let dbPath:string = "";
    this.uploadService.upload(formData).subscribe({
      next: (event) => {
          if(event.type === HttpEventType.Response){
            dbPath = event.body.dbPath;
          }
      },
      complete: () => {this.updateImgUser(dbPath);}
    })
  }

  updateImgUser(imgPath: string) {
    this.userService.getById(this.userLoguedId).subscribe(user => {
      user.imgPerfil = `${environment.url}/${imgPath}`;
      this.userService.update(user, this.userLoguedId).subscribe(() => {
        this.authService.updateImgUser(user.imgPerfil)

        console.log("Se cambio la imagen correctamente");
      })
    })
  }

  
}



