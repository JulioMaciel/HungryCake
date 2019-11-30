import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';
import { GridService } from '../_services/grid.service';
import { Grid } from '../_models/grid';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  userGrids: Grid[] = [];
  showGridConfig: boolean;
  @Output() changeGridConfig = new EventEmitter<boolean>();

  constructor(public authService: AuthService, private alertify: AlertifyService,
              private router: Router, public gridService: GridService) { }

  ngOnInit() {
    this.authService.currentUserGrids.subscribe(userGrids => {
      this.userGrids = userGrids;
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authService.decodedToken = null;
    this.authService.currentUser = null;
    this.alertify.message('Logged out!');
    this.router.navigate(['home']);
  }

  onAddGrid() {
    this.gridService.addGrid(this.authService.currentUser.id).subscribe(res => {
      this.alertify.success('Grid was inserted!');
      const gridId = res;
      const addedGrid: Grid = {
        id: +gridId,
        name: 'Untitled Grid'
      };
      this.userGrids.push(addedGrid);
      this.authService.changeUserGrid(this.userGrids);
      this.authService.currentUser.grids = this.userGrids;
      localStorage.setItem('user', JSON.stringify(this.authService.currentUser));
      this.router.navigate(['grid/' + gridId]);
    }, error => {
      this.alertify.error(error);
    }, () => {
    });
  }

  setGridConfigVisibility() {
    this.showGridConfig = !this.showGridConfig;
    this.changeGridConfig.emit(this.showGridConfig);
  }

}
