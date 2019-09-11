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
import { RolesModalComponent } from './users/roles-modal/roles-modal.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/hasRole.directive';
import { OverlayModule } from '@angular/cdk/overlay';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AlertifyService } from './_services/alertify.service';
import { CategoryListResolver } from './_resolvers/category-list.resolver';
import { RssAddEditComponent } from './feeds/rss-add-edit/rss-add-edit.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { CategoryListChildComponent } from './categories/category-list-child/category-list-child.component';
import { TreeCategoriesComponent } from './categories/tree-categories/tree-categories.component';
import { TreeviewModule } from 'ngx-treeview';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TimeAgoPipe } from 'time-ago-pipe';

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
      RssAddEditComponent,
      CategoryListComponent,
      CategoryListChildComponent,
      TreeCategoriesComponent,
      TimeAgoPipe
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
      TreeviewModule.forRoot(),
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
      CategoryListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
