import { Component, EventEmitter, OnInit, Output, inject, signal } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators  } from '@angular/forms';
import { CustomErrorStateMatcher } from '../../../_common/validators/custom-error-state-matcher';
import { Usuario } from '../../../models/usuario';
import { UsuarioService } from '../../../services/usuario.service';
import { PasswordStrengthValidator } from '../../../_common/validators/password-strength.validators';

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
		ReactiveFormsModule
	],
	templateUrl: './cadastro.component.html',
	styleUrl: './cadastro.component.scss'
})
export class CadastroComponent implements OnInit {
	hide = signal(true);
	matcher = signal(new CustomErrorStateMatcher());
	form: FormGroup;
	usuario: Usuario;

	@Output() exibirPainel: EventEmitter<string> = new EventEmitter<string>();

	private usuarioService = inject(UsuarioService);
	private fb = inject(FormBuilder);

	ngOnInit(): void {
		this.createForm();
	}

	createForm(): void { 
		this.form = this.fb.group({
            nome: ['', [Validators.required]],
            email: ['', [Validators.required, Validators.email]],
            senha: ['', [Validators.required, PasswordStrengthValidator]],
            telefone: [''],
            confirmarSenha: ['']
        }, { validator: this.checkPasswords });
	}

	checkPasswords(group: FormGroup) {
        let pass = group.controls.senha.value;
        let confirmPass = group.controls.confirmarSenha.value;

        return pass === confirmPass ? null : { notSame: true }
    }

	createUsuario(): void {
		if (this.form.invalid) {
            //this.notifierService.showNotification('Dados inválidos', 'Erro', 'error');
            return;
        }

        this.usuario = this.form.value;
        this.usuarioService.createUsuario(this.usuario).subscribe((response: any) => {
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
