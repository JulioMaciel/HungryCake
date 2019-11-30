import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Grid } from '../_models/grid';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GridService {
  baseUrl = environment.apiUrl + 'grids/';
  private showGridConfig = new Subject();
  // private virtualActiveGrid = new Subject();

  constructor(private http: HttpClient) { }

  addGrid(userId: number) {
    return this.http.post(this.baseUrl + 'add/' + userId, null);
  }

  updateGrid(grid: Grid) {
    return this.http.put(this.baseUrl + grid.id, grid);
  }

  loadGrid(gridId: number) {
    // console.log(gridId);
    return this.http.get<Grid>(this.baseUrl + gridId);
  }

  // getUserGrids(userId: number) { // ja recebe no momento do login
  //   return this.http.get<Grid[]>(this.baseUrl + 'grid/' + userId);
  // }

  // updateGrids(userId: number) {
  //   return this.http.get<Grid[]>(this.baseUrl + 'grid/' + userId);
  // }

  getGridConfigVisibility() {
    return this.showGridConfig;
  }

  updateGridConfigVisibility(val: boolean) {
      this.showGridConfig.next(val);
  }

  // getVirtualGrid() {
  //   return this.virtualActiveGrid;
  // }

  // updateVirtualGrid(grid: Grid) {
  //     this.virtualActiveGrid.next(grid);
  // }

  // getColumns(gridId: number) {
  // }

}
