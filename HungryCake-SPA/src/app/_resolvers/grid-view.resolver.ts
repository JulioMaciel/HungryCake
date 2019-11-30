import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import { FeedRss } from '../_models/feeds/feedRss';
import { FeedService } from '../_services/feed.service';
import { Grid } from '../_models/grid';
import { GridService } from '../_services/grid.service';

@Injectable()
export class GridViewResolver implements Resolve<Grid> {

    constructor(private gridService: GridService, private alertify: AlertifyService) { }

    resolve(route: ActivatedRouteSnapshot): Observable<Grid> {
        // console.log(route.params.id);
        return this.gridService.loadGrid(route.params.id).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                return of(null);
            })
        );
    }

}
