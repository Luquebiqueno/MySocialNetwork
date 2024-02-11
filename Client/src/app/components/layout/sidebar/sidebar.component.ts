import { Component, Input, OnInit, inject, signal } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDialog } from '@angular/material/dialog';
import { Menu } from '../../../models/menu';
import { MenuService } from '../../../services/menu.service';
import { CriarComponent } from '../../criar/criar.component';

@Component({
	selector: 'app-sidebar',
	standalone: true,
	imports: [
		RouterLinkActive,
    	RouterLink, 
    	MatIconModule,
    	MatListModule,
		MatDialogModule
	],
	templateUrl: './sidebar.component.html',
	styleUrl: './sidebar.component.scss'
})
export class SidebarComponent implements OnInit {
	@Input({
		required: true,
			transform: (value: boolean) => value
		})
	sidenavCollapsed = signal(false);
	menuList = signal<Menu[]>([]);

	private menuService = inject(MenuService);
	private dialog = inject(MatDialog);

	ngOnInit(): void {
        this.menuService.getMenu().subscribe((response: any) => {
            this.menuList.set(response);
        });
    }

	abrirModalCriar(): void {
        this.dialog.open(CriarComponent);
    }
}
