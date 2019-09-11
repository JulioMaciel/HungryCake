import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { RssAddEditComponent } from './feeds/rss-add-edit/rss-add-edit.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { CategoryListResolver } from './_resolvers/category-list.resolver';
import { TreeCategoriesComponent } from './categories/tree-categories/tree-categories.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            // { path: 'feeds', component: FeedListComponent, resolve: {users: FeedListResolver}},
            { path: 'rss/add', component: RssAddEditComponent},
            // { path: 'feed/edit/:id', component: RssAddEditComponent, resolve: {user: FeedEditResolver}},
            { path: 'categories', component: CategoryListComponent, resolve: {categories: CategoryListResolver}},
            { path: 'tree-categories', component: TreeCategoriesComponent, resolve: {categories: CategoryListResolver} },
            { path: 'admin', component: AdminPanelComponent, data: {roles: ['Admin']}},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
