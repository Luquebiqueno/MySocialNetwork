import { Injectable, inject, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioLogin } from '../models/usuario-login';

@Injectable({
	providedIn: 'root'
})
export class AutenticacaoService {
	url = signal(environment.host + 'Autenticacao');
	private http = inject(HttpClient);

	getAutenticacao(usuarioLogin: UsuarioLogin): Observable<any> {
        return this.http.post(this.url(), usuarioLogin);
    }
}
