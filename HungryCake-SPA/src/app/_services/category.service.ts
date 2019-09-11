import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'categories');
  }

  add(category: Category) {
    return this.http.post(this.baseUrl + 'categories/add', category);
  }

  delete(catId: number) {
    return this.http.delete(this.baseUrl + 'categories/' + catId);
  }

  update(category: Category) {
    return this.http.put(this.baseUrl + 'categories/' + category.id, category);
  }

}
