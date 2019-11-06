import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { FeedRss } from '../_models/feeds/feedRss';
import { FeedService } from '../_services/feed.service';

@Injectable()
export class RssListResolver implements Resolve<FeedRss[]> {

    constructor(private feedService: FeedService, private alertify: AlertifyService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<FeedRss[]> {
        return this.feedService.getRssList().pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                return of(null);
            })
        );
    }

}
