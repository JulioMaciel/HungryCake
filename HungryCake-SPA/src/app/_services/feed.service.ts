import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';
import { Feed } from '../_models/feed';

@Injectable({
  providedIn: 'root'
})
export class FeedService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

getFeeds(page?, itemsPerPage?): Observable<PaginatedResult<Feed[]>> {
  const paginatedResult: PaginatedResult<Feed[]> = new PaginatedResult<Feed[]>();

  let params = new HttpParams();

  if (page != null && itemsPerPage != null) {
    params = params.append('pageNumber', page);
    params = params.append('pageSize', itemsPerPage);
  }

  // if (userParams != null) {
  //   params = params.append('orderBy', userParams.orderBy);
  // }

  return this.http.get<Feed[]>(this.baseUrl + 'feeds', { observe: 'response', params}).pipe(
    map(response => {
      paginatedResult.result = response.body;
      if (response.headers.get('Pagination') != null) {
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
      }
      return paginatedResult;
    })
  );
}

getFeed(id: number): Observable<Feed> {
  return this.http.get<Feed>(this.baseUrl + 'feeds/' + id);
}

}
