import { HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { ChangeDetectorRef, Component, EventEmitter, inject, OnDestroy, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { BehaviorSubject, Observable, Subject, switchMap, take, tap } from 'rxjs';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { UploadService } from 'src/app/core/services/upload.service';
import { UserService } from 'src/app/core/services/user.service';
import { environment } from 'src/environments/environment';
import { ActualUserRouteService } from '../../core/services/component-comunication/actual-user-route.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css'],
})
export class UsuarioComponent implements OnInit {

  private profileRoutes:string[] = ["/usuario","/usuario/account-details", "/usuario/edit-profile"];

  isProfile = true;


  private _router = inject(Router);

  userLoguedId!: number;
  userImgPerfil$!: Observable<string>;
  userLogued?: User;
  $userLogued? : Subject<string>
  $titleRoute!: Observable<string>;
  $backRoute!: Observable<string>;
  constructor(
    private authService: AuthService,
    private readonly uploadService: UploadService,
    private readonly userService: UserService,
    private readonly actualUserRoute:ActualUserRouteService
  ) {}

  ngOnInit(): void {

    this._router.events.pipe().subscribe(event =>{
      if(this.isProfile = this.isRouteInProfile(this._router.url) ){
        this.setUser();
      }
    })

    this.userImgPerfil$ = this.authService.getImgUserLogin();
    if(this.isRouteInProfile(this._router.url)){  
    }

      this.$titleRoute = this.actualUserRoute.getTitleRoute();
      this.$backRoute = this.actualUserRoute.getBackRoute();
  }
  
  
  uploadFile(file: any) {
    if (file.lenght === 0) {
      return;
    }
    let fileToUpload = <File>file[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    let dbPath: string = '';
    this.uploadService.upload(formData).subscribe({
      next: (event) => {
        if (event.type === HttpEventType.Response) {
          dbPath = event.body.dbPath;
        }
      },
      complete: () => {
        this.updateImgUser(dbPath);
      },
    });
  }

  updateImgUser(imgPath: string) {
    this.userService.getById(this.userLoguedId).subscribe((user) => {
      user.imgPerfil = `${environment.url}/${imgPath}`;
      this.userService.update(user, this.userLoguedId).subscribe(() => {
        this.authService.updateImgUser(user.imgPerfil);

        console.log('Se cambio la imagen correctamente');
      });
    });
  }

  isRouteInProfile(route:string):boolean{
    let inProfile = false;
    this.profileRoutes.forEach(element => {
       inProfile ||= (element === route);
    });
    return inProfile;
  }

  setUser(){
    
    this.userLoguedId = this.authService.getCurrentUserLogued()?.id!;
    this.userService.getById(this.userLoguedId).subscribe(value =>{
      this.userLogued = value;
    })
  }
} 



