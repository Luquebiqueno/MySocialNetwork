import { Routes } from '@angular/router';
import { NavComponent } from './_common/components/layout/nav/nav.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { AnalyticsComponent } from './components/analytics/analytics.component';

export const routes: Routes = [
    {
        path: '', 
        component: NavComponent,
        children: [
            {
                path: 'dashboard',
                pathMatch: 'full',
                component: DashboardComponent,
            },
            {
                path: 'perfil',
                component: PerfilComponent,
            },
            {
                path: 'analytics',
                component: AnalyticsComponent
            }
        ]
    }
];
