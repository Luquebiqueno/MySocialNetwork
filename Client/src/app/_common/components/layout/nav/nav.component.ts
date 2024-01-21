import { Component, computed, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SidebarComponent } from '../sidebar/sidebar.component';

@Component({
	selector: 'app-nav',
	standalone: true,
	imports: [
		RouterOutlet,
    	MatIconModule,
    	MatButtonModule,
    	MatToolbarModule,
    	MatSidenavModule,
    	SidebarComponent
	],
	templateUrl: './nav.component.html',
	styleUrl: './nav.component.scss'
})
export class NavComponent {
	collapsed = signal(true);
	sidenavWidth = computed(() => this.collapsed() ? '65px' : '200px');
}
