import { Component, Input, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { Menu } from '../../../models/menu';

@Component({
	selector: 'app-sidebar',
	standalone: true,
	imports: [
		RouterLinkActive,
    	RouterLink, 
    	MatIconModule,
    	MatListModule
	],
	templateUrl: './sidebar.component.html',
	styleUrl: './sidebar.component.scss'
})
export class SidebarComponent {
	@Input({ required: true, transform: (value: boolean) => value })
	sidenavCollapsed = signal(false);
	menuList = signal<Menu[]>([
		{
			"descricao": "Dashboard",
			"icone": "dashboard",
			"routerLink": "dashboard"
		},
		{
			"descricao": "Perfil",
			"icone": "person",
			"routerLink": "perfil"
		},
		{
			"descricao": "Analytics",
			"icone": "analytics",
			"routerLink": "analytics"
		}
	]);
}
