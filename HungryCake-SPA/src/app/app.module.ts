import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { UserAddComponent } from './users/user-add/user-add.component';
import { appRoutes } from './routes';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule, PaginationModule, ButtonsModule, ModalModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthService } from './_services/auth.service';
import { AuthGuard } from './_guards/auth.guard';
import { UserService } from './_services/user.service';
import { AdminService } from './_services/admin.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { RolesModalComponent } from './admin/roles-modal/roles-modal.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/hasRole.directive';
import { OverlayModule } from '@angular/cdk/overlay';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlertifyService } from './_services/alertify.service';
import { FeedListComponent } from './feeds/feed-list/feed-list.component';
import { FeedService } from './_services/feed.service';
import { FeedAddEditComponent } from './feeds/feed-add-edit/feed-add-edit.component';
import { FeedListResolver } from './_resolvers/feed-list.resolver';
import { FeedEditResolver } from './_resolvers/feed-edit.resolver';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      UserAddComponent,
      AdminPanelComponent,
      RolesModalComponent,
      HasRoleDirective,
      FeedListComponent,
      FeedAddEditComponent,
      NavComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      OverlayModule,
      BrowserAnimationsModule,
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
      RolesModalComponent
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AuthGuard,
      UserService,
      AdminService,
      AlertifyService,
      FeedService,
      FeedListResolver,
      FeedEditResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
