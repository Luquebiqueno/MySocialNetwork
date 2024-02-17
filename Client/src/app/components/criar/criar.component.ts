import { Component, OnInit, ViewChild, inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Publicacao } from '../../models/publicacao';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { PublicacaoService } from '../../services/publicacao.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-criar',
	standalone: true,
	imports: [
		MatCardModule,
		MatFormFieldModule,
		MatInputModule,
		MatButtonModule,
		MatIconModule,
		MatDividerModule,
		FormsModule,
		ReactiveFormsModule
	],
	templateUrl: './criar.component.html',
	styleUrl: './criar.component.scss'
})
export class CriarComponent implements OnInit {
	@ViewChild('autosize') autosize: CdkTextareaAutosize;
	form: FormGroup;
	publicacao: Publicacao;

	private publicacaoService = inject(PublicacaoService);
	private fb = inject(FormBuilder);
	private router = inject(Router);

	ngOnInit(): void {
		this.createForm();
	}

	createForm(): void { 
		this.form = this.fb.group({
            texto: ['', [Validators.required]]
        });
	}

	voltar() {
		this.router.navigate(['../home']);
	}

	salvar() {
		if (this.form.invalid) {
            //this.notifierService.showNotification('Dados inválidos', 'Erro', 'error');
            return;
        }

        this.publicacao = this.form.value;
        this.publicacaoService.createPublicacao(this.publicacao).subscribe((response: any) => {
            //this.notifierService.showNotification('Usuário cadastrado com sucesso','Sucesso', 'success');
        },
        error => {
            //this.notifierService.showNotification('Aconteceu um erro', 'Erro', 'error');
            return;
        });
	}
}
