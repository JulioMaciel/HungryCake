import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { BehaviorSubject } from 'rxjs';
import { Grid } from '../_models/grid';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;
  // userGrids: Grid[];
  userGrids = new BehaviorSubject<Grid[]>([]);
  currentUserGrids = this.userGrids.asObservable();

  constructor(private http: HttpClient) { }

  changeUserGrid(userGrids: Grid[]) {
    this.userGrids.next(userGrids);
  }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', JSON.stringify(user.user));
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          // console.log(user);
          this.currentUser = user.user;
          // this.userGrids = user.userGrids;
          this.changeUserGrid(this.currentUser.grids);
        }
      })
    );
  }

  register(user: User) {
    return this.http.post(this.baseUrl + 'register', user);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  levelMatch(levelRequired: number): boolean {
    let isMatch = false;
    const userLevel = this.decodedToken.level as number;

    if (userLevel === levelRequired) {
      isMatch = true;
      return;
    }

    return isMatch;
  }

}
