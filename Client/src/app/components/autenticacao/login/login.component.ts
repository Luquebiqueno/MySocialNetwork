import { Component, EventEmitter, Output, inject, signal } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { UsuarioLogin } from '../../../models/usuario-login';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FormDirective } from '../../../_common/directives/form.directive';
import { AutenticacaoService } from '../../../services/autenticacao.service';
import { UsuarioAutenticado } from '../../../models/usuario-autenticado';

@Component({
	selector: 'app-login',
	standalone: true,
	imports: [
		MatCardModule,
		MatFormFieldModule,
		MatInputModule,
		MatButtonModule,
		FormsModule,
		FormDirective
	],
	templateUrl: './login.component.html',
	styleUrl: './login.component.scss'
})
export class LoginComponent {
	usuarioLogin = signal<UsuarioLogin>({});
	@Output() exibirPainel: EventEmitter<string> = new EventEmitter<string>();

	private autenticacaoService = inject(AutenticacaoService);
	private router = inject(Router);

	login(): void {
		this.autenticacaoService.getAutenticacao(this.usuarioLogin()).subscribe((usuarioAutenticado: UsuarioAutenticado) => {
            if (usuarioAutenticado.authenticated) {
                if (usuarioAutenticado && usuarioAutenticado.accessToken) {
                    localStorage['usuarioAutenticado'] = JSON.stringify(usuarioAutenticado);
                    //this.notifierService.showNotification(usuarioAutenticado.message,'Sucesso', 'success');
                    this.router.navigate(['dashboard']);
                } else {
                    //this.notifierService.showNotification('Ocorreu um erro ao autenticar.','Erro', 'error');
                }
            } else {
                //this.notifierService.showNotification(usuarioAutenticado.message,'Erro', 'error');
            }
        });
	}

	exibirPainelCadastro(): void {
        this.exibirPainel.emit('cadastro');
    }

    esqueciMinhaSenha(): void {
        this.router.navigate(['esqueci-minha-senha']);
    }
}
