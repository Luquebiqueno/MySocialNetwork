import { Routes } from '@angular/router';
import { authGuard } from './_helpers/auth.guard';
import { NavComponent } from './components/layout/nav/nav.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { AutenticacaoComponent } from './components/autenticacao/autenticacao.component';
import { EsqueciMinhaSenhaComponent } from './components/autenticacao/esqueci-minha-senha/esqueci-minha-senha.component';
import { HomeComponent } from './components/home/home.component';
import { CriarComponent } from './components/criar/criar.component';
import { NotificacoesComponent } from './components/notificacoes/notificacoes.component';
import { ChatComponent } from './components/chat/chat.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'autenticacao',
        pathMatch: 'full'
    },
    {
        path: 'autenticacao', 
        component: AutenticacaoComponent
    },
    {
        path: 'esqueci-minha-senha', 
        component: EsqueciMinhaSenhaComponent
    },
    {
        path: '', 
        component: NavComponent,
        canActivate: [authGuard],
        children: [
            {
                path: 'home',
                pathMatch: 'full',
                component: HomeComponent,
                canActivate: [authGuard]
            },
            {
                path: 'dashboard',
                component: DashboardComponent,
                canActivate: [authGuard]
            },
            {
                path: 'perfil',
                component: PerfilComponent,
                canActivate: [authGuard]
            },
            {
                path: 'criar',
                component: CriarComponent,
                canActivate: [authGuard]
            },
            {
                path: 'notificacoes',
                component: NotificacoesComponent,
                canActivate: [authGuard]
            },
            {
                path: 'chat',
                component: ChatComponent,
                canActivate: [authGuard]
            }
        ]
    }
];
