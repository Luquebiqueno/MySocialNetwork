import { Routes } from '@angular/router';
import { NavComponent } from './components/layout/nav/nav.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { AnalyticsComponent } from './components/analytics/analytics.component';
import { AutenticacaoComponent } from './components/autenticacao/autenticacao.component';
import { EsqueciMinhaSenhaComponent } from './components/autenticacao/esqueci-minha-senha/esqueci-minha-senha.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'autenticacao',
        pathMatch: 'full',
    },
    {
        path: 'autenticacao', 
        component: AutenticacaoComponent,
    },
    {
        path: 'esqueci-minha-senha', 
        component: EsqueciMinhaSenhaComponent,
    },
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
