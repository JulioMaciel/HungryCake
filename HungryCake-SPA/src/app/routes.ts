import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { RssAddEditComponent } from './feeds/rss/rss-add-edit/rss-add-edit.component';
import { RssEditResolver } from './_resolvers/rss-edit.resolver';
import { GridViewComponent } from './grid/grid-view/grid-view.component';
import { RssListComponent } from './feeds/rss/rss-list/rss-list.component';
import { RssListResolver } from './_resolvers/rss-list.resolver';
import { GridEditComponent as GridEditComponent } from './grid/grid-edit/grid-edit.component';
import { ColumnEditComponent as ColumnEditComponent } from './column/column-edit/column-edit.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'main', component: GridViewComponent},
            { path: 'grid/edit', component: GridEditComponent},
            { path: 'column/edit', component: ColumnEditComponent},
            { path: 'rss/add', component: RssAddEditComponent},
            { path: 'rss/edit/:id', component: RssAddEditComponent, resolve: {rssToEdit: RssEditResolver}},
            { path: 'rss/list', component: RssListComponent, resolve: {rssList: RssListResolver}},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
