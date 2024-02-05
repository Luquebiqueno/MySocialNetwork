import { Injectable, inject, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../models/usuario';
import { AlterarSenha } from '../models/alterar-senha';

@Injectable({
	providedIn: 'root'
})
export class UsuarioService {
	url = signal(environment.host + 'Usuario');
	private http = inject(HttpClient);

	getUsuario(): Observable<Usuario[]> {
		return this.http.get<Usuario[]>(this.url());
	}

	getUsuarioLogado(): Observable<Usuario> {
		return this.http.get<Usuario>(this.url() + '/UsuarioLogado');
	}

	getUsuarioById(id: number): Observable<Usuario> {
		return this.http.get<Usuario>(this.url() + '/' + id);
	}

	createUsuario(model: any) : Observable<Usuario> {
		return this.http.post<Usuario>(this.url(), model);
	}

	updateUsuario(id: number, model: Usuario): Observable<Usuario> {
		return this.http.put<Usuario>(this.url() + '/' + id, model);
	}

	deleteUsuario(): Observable<any> {
		return this.http.put<Usuario>(this.url() + '/DeleteUsuario', null);
	}

	alterarSenha(model: AlterarSenha): Observable<any> {
		return this.http.put<AlterarSenha>(this.url() + '/AlterarSenha', model);
	}
}
