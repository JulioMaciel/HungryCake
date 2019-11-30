import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { PaginatedResult } from '../_models/pagination';
import { map } from 'rxjs/operators';
import { FeedRss } from '../_models/feeds/feedRss';
import { RssItem } from '../_models/feeds/items/rssItem';
import { Feed } from '../_models/feeds/feed';
import { Filter } from '../_models/filter';
import { Column } from '../_models/column';

@Injectable({
  providedIn: 'root'
})
export class FeedService {
  baseUrl = environment.apiUrl + 'feeds/';

  constructor(private http: HttpClient) { }

  getRssPreview(rssUrl: string): Observable<RssItem[]> {
    const params = new HttpParams().append('RssUrl', rssUrl);
    return this.http.get<RssItem[]>(this.baseUrl + 'rss', { params });
  }

  addRss(rss: FeedRss) {
    return this.http.post(this.baseUrl + 'rss/add', rss);
  }

  updateRss(rss: FeedRss) {
    return this.http.put(this.baseUrl + 'rss/' + rss.id, rss);
  }

  getRss(rssId: number) {
    return this.http.get<FeedRss>(this.baseUrl + 'rss/' + rssId);
  }

  getRssList() {
    return this.http.get<FeedRss[]>(this.baseUrl + 'rss/list');
  }

  importRssDescription(url: string) {
    const params = new HttpParams().append('url', url);
    return this.http.get(this.baseUrl + 'rss/description', { params });
  }

  tryRssIcon(url: string) {
    const params = new HttpParams().append('url', url);
    return this.http.get(this.baseUrl + 'rss/icon', { params });
  }

  // addFilter(filter: Filter) {
  //   return this.http.post(this.baseUrl + 'filter/add', filter);
  // }

  // updateFilter(filter: Filter) {
  //   return this.http.put(this.baseUrl + 'filter/' + filter.id, filter);
  // }

}
