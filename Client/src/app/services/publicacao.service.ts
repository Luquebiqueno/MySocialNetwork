import { Injectable, inject, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Publicacao } from '../models/publicacao';

@Injectable({
	providedIn: 'root'
})
export class PublicacaoService {
	url = signal(environment.host + 'Publicacao');
	private http = inject(HttpClient);

	getPublicacao(): Observable<Publicacao[]> {
		return this.http.get<Publicacao[]>(this.url());
	}

	getPublicacaoById(id: number): Observable<Publicacao> {
		return this.http.get<Publicacao>(this.url() + '/' + id);
	}

	createPublicacao(model: any) : Observable<Publicacao> {
		return this.http.post<Publicacao>(this.url(), model);
	}

	updatePublicacao(id: number, model: Publicacao): Observable<Publicacao> {
		return this.http.put<Publicacao>(this.url() + '/' + id, model);
	}

	deletePublicacao(): Observable<any> {
		return this.http.put<Publicacao>(this.url() + '/DeletePublicacao', null);
	}
}
