import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { FeedListComponent } from './feeds/feed-list/feed-list.component';
import { FeedListResolver } from './_resolvers/feed-list.resolver';
import { FeedAddEditComponent } from './feeds/feed-add-edit/feed-add-edit.component';
import { FeedEditResolver } from './_resolvers/feed-edit.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'feeds', component: FeedListComponent, resolve: {users: FeedListResolver}},
            { path: 'feed/add', component: FeedAddEditComponent},
            { path: 'feed/edit/:id', component: FeedAddEditComponent, resolve: {user: FeedEditResolver}},
            { path: 'admin', component: AdminPanelComponent, data: {roles: ['Admin']}},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
