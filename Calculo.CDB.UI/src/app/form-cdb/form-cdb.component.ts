import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

interface CdbResponse {
  ValorInicial: number | null;
  PrazoMes: number;
  ValorBruto: number | null;
  ValorImposto: number | null;
  ValorLiquido: number | null;
  Cdi: number | null;
  TaxaBanco: number | null;
}

@Component({
  selector: 'app-form-cdb',
  templateUrl: './form-cdb.component.html',
  styleUrls: ['./form-cdb.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, HttpClientModule, CommonModule]
})
export class FormCdbComponent {
  cdbForm!: FormGroup;
  resultado: CdbResponse | null = null;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.cdbForm = this.fb.group({
      mes: ['', [Validators.required, Validators.min(1), Validators.max(12)]],
      valor: ['', [Validators.required, Validators.pattern('^\\d+(\\.\\d{1,2})?$')]]
    });
  }

  onSubmit(): void {

    console.log("enviando dados...", this.cdbForm.value);

    if (this.cdbForm.valid) {
      const { mes, valor } = this.cdbForm.value;
      const url = `http://localhost:44362/api/calculo?valorInicial=${valor}&prazoMes=${mes}`;
      
      this.http.get<CdbResponse>(url)
        .subscribe(
          response => {
            console.log('Resposta da API:', response);
            this.resultado = response;
          },
          error => {
            console.error('Erro ao chamar a API:', error);
          }
        );
    }
  }

}
