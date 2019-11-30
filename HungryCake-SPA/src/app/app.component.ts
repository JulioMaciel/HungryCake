import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './_services/auth.service';
import { User } from './_models/user';
import { GridViewComponent } from './grid/grid-view/grid-view.component';
import { GridService } from './_services/grid.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'HungryCake-SPA';
  jwtHelper = new JwtHelperService();

  constructor(private authService: AuthService, private gridService: GridService) { }

  ngOnInit() {
    const token = localStorage.getItem('token');
    const user: User = JSON.parse(localStorage.getItem('user'));
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
    if (user) {
      this.authService.currentUser = user;
      this.authService.changeUserGrid(user.grids);
    }
  }

  updateGridConfigVisibility(value: boolean) {
    this.gridService.updateGridConfigVisibility(value);
  }
}
