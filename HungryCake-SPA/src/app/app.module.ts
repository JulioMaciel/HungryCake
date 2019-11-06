import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { appRoutes } from './routes';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule, PaginationModule, ButtonsModule, ModalModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { OverlayModule } from '@angular/cdk/overlay';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TimeAgoPipe } from 'time-ago-pipe';
import { ErrorInterceptorProvider } from './_services/error.interceptor';

import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { HasLevelDirective } from './_directives/hasLevel.directive';
import { RssEditResolver } from './_resolvers/rss-edit.resolver';
import { RssListResolver } from './_resolvers/rss-list.resolver';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { UserAddComponent } from './users/user-add/user-add.component';
import { GridViewComponent } from './grid/grid-view/grid-view.component';
import { GridEditComponent } from './grid/grid-edit/grid-edit.component';
import { ColumnViewComponent } from './column/column-view/column-view.component';
import { ColumnEditComponent } from './column/column-edit/column-edit.component';
import { RssListComponent } from './feeds/rss/rss-list/rss-list.component';
import { RssAddEditComponent } from './feeds/rss/rss-add-edit/rss-add-edit.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      HasLevelDirective,
      TimeAgoPipe,
      NavComponent,
      HomeComponent,
      UserAddComponent,
      GridViewComponent,
      GridEditComponent,
      ColumnViewComponent,
      ColumnEditComponent,
      RssListComponent,
      RssAddEditComponent,
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      OverlayModule,
      BrowserAnimationsModule,
      NgbModule,
      BsDropdownModule.forRoot(),
      PaginationModule.forRoot(),
      TabsModule.forRoot(),
      ButtonsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      ModalModule.forRoot(),
      JwtModule.forRoot({
         config: {
            tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   entryComponents: [
      // RolesModalComponent
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AuthGuard,
      UserService,
      AlertifyService,
      RssEditResolver,
      RssListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
