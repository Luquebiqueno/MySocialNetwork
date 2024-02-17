import { Component, OnInit, inject, signal } from '@angular/core';
import { PublicacaoService } from '../../services/publicacao.service';
import { Publicacao } from '../../models/publicacao';

@Component({
	selector: 'app-home',
	standalone: true,
	imports: [],
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
