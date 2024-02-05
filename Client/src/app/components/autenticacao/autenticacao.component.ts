import { Component, signal } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';

@Component({
	selector: 'app-autenticacao',
	standalone: true,
	imports: [
		LoginComponent,
		CadastroComponent
	],
	template: `
		@if (cadastro()) {
			<app-cadastro (exibirPainel)="exibirPainel($event)" />
		} @else {
			<app-login (exibirPainel)="exibirPainel($event)" />
		}
	`
})
export class AutenticacaoComponent {
	cadastro = signal(false);
	exibirPainel(event: string): void {
        this.cadastro.update(() => event === 'cadastro' ? true : false);
    }
}
