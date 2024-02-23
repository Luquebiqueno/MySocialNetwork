import { Component, OnInit, inject, signal } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { PublicacaoService } from '../../services/publicacao.service';
import { Publicacao } from '../../models/publicacao';

@Component({
	selector: 'app-home',
	standalone: true,
	imports: [
		MatCardModule,
		MatButtonModule,
		MatIconModule,
		MatDividerModule
	],
	templateUrl: './home.component.html',
	styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
	publicacaoList = signal<Publicacao[]>([]);

	private publicacaoService = inject(PublicacaoService);

	ngOnInit(): void {
        this.getPublicacao();
    }

	getPublicacao() {
		this.publicacaoService.getPublicacao().subscribe((response: Publicacao[]) => {
            this.publicacaoList.set(response);
        });
	}
}
