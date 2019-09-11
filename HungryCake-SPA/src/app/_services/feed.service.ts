import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';
import { Rss } from '../_models/rss';
import { Category } from '../_models/category';
import { RssItem } from '../_models/rssItem';

@Injectable({
  providedIn: 'root'
})
export class FeedService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getRssPreview(rssUrl: string): Observable<RssItem[]> {

    let params = new HttpParams();
    params = params.append('RssUrl', rssUrl);

    return this.http.get<RssItem[]>(this.baseUrl + 'feeds/', { params });
  }

  add(rss: Rss) {
    return this.http.post(this.baseUrl + 'feeds/add', rss);
  }

}
