import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { Feed } from '../_models/feed';
import { FeedService } from '../_services/feed.service';

@Injectable()
export class FeedListResolver implements Resolve<Feed[]> {
    pageNumber = 1;
    pageSize = 5;

    constructor(private feedService: FeedService, private router: Router, private alertify: AlertifyService) { }

    resolve(): Observable<Feed[]> {
        return this.feedService.getFeeds(this.pageNumber, this.pageSize)
                .pipe(
                    catchError(error => {
                        this.alertify.error('Problem retrieving feeds');
                        this.router.navigate(['/home']);
                        return of(null);
                    })
        );
    }

}
