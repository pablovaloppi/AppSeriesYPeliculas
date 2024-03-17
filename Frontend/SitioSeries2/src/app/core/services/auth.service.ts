import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthenticatedResponse } from '../models/authenticatedResponse';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Login } from '../models/login';
import { User, UserType } from '../models/user';
import { UserLogin } from '../models/userLogin';
import { UserService } from './user.service';
import { ChangePaswordLogin } from '../models/changePasswordLogin';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _isLogin = new BehaviorSubject<boolean>(false);
  private _isAdminOrMod = new BehaviorSubject<boolean>(false);
  private _imgPerfil = new BehaviorSubject<string>('');

  private _tokenLocalStore = 'token_access'
  private _nameLocalStore = 'loginInfo'
  private _userLocalStore = 'userInfo'

  private apiPath: string = environment.api;

  constructor(private readonly http: HttpClient,
      private readonly userService:UserService) { }

  login(login: Login): Observable<AuthenticatedResponse> {
    return this.http.post<AuthenticatedResponse>(`${this.apiPath}/auth`, login);
  }

  changePassword(change:ChangePaswordLogin):Observable<void>{
    return this.http.put<void>(`${this.apiPath}/auth`, change);
  }

  saveLoginInLocalStorage(user: UserLogin, token: string): void {
    let sotrage = { 'userInfo': user, 'token_access': token };

    localStorage.setItem('loginInfo', JSON.stringify(sotrage));

    this._isLogin.next(true);
    this._imgPerfil.next(user.imgPerfil);

    this.setUserType(user);
  }

  hasLogued(): boolean {
    let user = this.getCurrentUserLogued();
    this._isLogin.next(  user != null ? true : false);
    if(user){
      this._imgPerfil.next(user.imgPerfil);
    }
    return this.getCurrentUserLogued() ? true : false;
  }

  isInLogin(): Observable<boolean> {
    return this._isLogin;
  }


  verifyLogin(state: boolean, user: UserLogin, token: string): boolean {
    if (state) {
      if (this.getToken() != null) {
        return true;
      }
      this.saveLoginInLocalStorage(user, token);
      return true;
    }
    return false;
  }

  getCurrentUserLogued(): UserLogin | null {
    if (!this.localStoreIsEmpty())
      return JSON.parse(localStorage.getItem(this._nameLocalStore)!)[this._userLocalStore];

    return null;
  }

  getCurrentIdLogued():number{
    return this.getCurrentUserLogued()?.id!;
  }
  getImgUserLogin():Observable<string>{
    return this._imgPerfil;
  }
  getImagenUserLogued():string{
    return this.getCurrentUserLogued()?.imgPerfil!;
  }
  getUserNameLogued():string{
    return this.getCurrentUserLogued()?.user!;
  }

  setUserType(user: UserLogin) {
    if (user != null) {
      if (user.tipoUsuarioId === UserType.ADMINISTRATOR || user.tipoUsuarioId === UserType.MODERATOR) {
        this._isAdminOrMod.next(true);
      }
      else {
        this._isAdminOrMod.next(false);
      }
    }
  }

  updateImgUser(img:string){
    let user = {...this.getCurrentUserLogued(), imgPerfil: img};
    let sotrage = { 'userInfo': user, 'token_access': this.getToken() };

    localStorage.setItem('loginInfo', JSON.stringify(sotrage));
    this._imgPerfil.next(user.imgPerfil);
  }
  isAdminOrMod(): Observable<boolean> {
    this._isAdminOrMod.next(this.userService.isAdminOrMod(this.getCurrentUserLogued()?.tipoUsuarioId!));
    return this._isAdminOrMod;
  }
  logout() {
    this._isLogin.next(false);
    localStorage.removeItem(this._nameLocalStore);
  }

  getToken(): string | null {
    
    if (!this.localStoreIsEmpty())
      return JSON.parse(localStorage.getItem(this._nameLocalStore)!)[this._tokenLocalStore]

    return null;
  }

  private localStoreIsEmpty(): boolean {
    return localStorage.getItem(this._nameLocalStore) === null;
  }
}
