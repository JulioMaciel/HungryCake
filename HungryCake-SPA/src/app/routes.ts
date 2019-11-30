import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { RssAddEditComponent } from './feeds/rss-add-edit/rss-add-edit.component';
import { RssEditResolver } from './_resolvers/rss-edit.resolver';
import { GridViewComponent } from './grid/grid-view/grid-view.component';
import { ListComponent } from './feeds/list/list.component';
import { RssListResolver } from './_resolvers/rss-list.resolver';
import { GridEditComponent as GridEditComponent } from './grid/grid-edit/grid-edit.component';
import { ColumnRssEditComponent } from './column/column-rss-edit/column-rss-edit.component';
import { GridViewResolver } from './_resolvers/grid-view.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'main', component: GridViewComponent},
            { path: 'grid/edit', component: GridEditComponent},
            { path: 'column/edit', component: ColumnRssEditComponent},
            { path: 'rss/add', component: RssAddEditComponent},
            { path: 'rss/edit/:id', component: RssAddEditComponent, resolve: {rssToEdit: RssEditResolver}},
            { path: 'feeds', component: ListComponent, resolve: {rssList: RssListResolver}},
            { path: 'grid/:id', component: GridViewComponent, resolve: {grid: GridViewResolver}},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
