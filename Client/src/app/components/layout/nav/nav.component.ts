import { Component, signal } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatBadgeModule } from '@angular/material/badge';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
	selector: 'app-nav',
	standalone: true,
	imports: [
		RouterOutlet,
		RouterLink,
    	MatIconModule,
    	MatButtonModule,
    	MatToolbarModule,
    	MatSidenavModule,
		MatBadgeModule,
    	SidebarComponent
	],
	templateUrl: './nav.component.html',
	styleUrl: './nav.component.scss'
})
export class NavComponent {
	collapsed = signal(true);
	qtdNotificacao = signal(35);
	qtdMensagem = signal(15);
}
