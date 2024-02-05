import { Component, EventEmitter, Output, inject, signal } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { CustomErrorStateMatcher } from '../../../_common/validators/custom-error-state-matcher';
import { Usuario } from '../../../models/usuario';
import { UsuarioService } from '../../../services/usuario.service';
import { FormDirective } from '../../../_common/directives/form.directive';

@Component({
	selector: 'app-cadastro',
	standalone: true,
	imports: [
		MatCardModule,
		MatFormFieldModule,
		MatInputModule,
		MatButtonModule,
		MatIconModule,
		FormsModule,
		ReactiveFormsModule,
		FormDirective
	],
	templateUrl: './cadastro.component.html',
	styleUrl: './cadastro.component.scss'
})
export class CadastroComponent {
	hide = signal(true);
	matcher = signal(new CustomErrorStateMatcher());
	usuario = signal<Usuario>({});

	@Output() exibirPainel: EventEmitter<string> = new EventEmitter<string>();

	private usuarioService = inject(UsuarioService);

	createUsuario(): void {
        this.usuarioService.createUsuario(this.usuario()).subscribe((response: any) => {
            //this.notifierService.showNotification('Usuário cadastrado com sucesso','Sucesso', 'success');
            this.exibirPainelLogin();
        },
        error => {
            //this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
            return;
        });
    }

	exibirPainelLogin(): void {
        this.exibirPainel.emit('login');
    }
}
