import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Column } from '../_models/column';

@Injectable({
  providedIn: 'root'
})
export class ColumnService {
  baseUrl = environment.apiUrl + 'cols/';

  constructor(private http: HttpClient) { }

  addColumn(userId: number) {
    return this.http.post(this.baseUrl + 'add', userId);
  }

  updateColumn(col: Column) {
    return this.http.put(this.baseUrl + col.id, col);
  }

}
