import { Router } from '@angular/router';
import { AlertaDialogComponent } from './../../shared/alerta-dialog/alerta-dialog.component';
import { VacinasService } from '../../services/VacinasService';
import { ElementDialogComponent } from '../../shared/element-dialog/element-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { Vacina } from 'src/app/models/Vacina';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AlertaDialogService } from 'src/app/shared/alerta-dialog.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-vacinas',
  templateUrl: './vacinas.component.html',
  styleUrls: ['./vacinas.component.scss'],
  providers: [VacinasService]
})

export class VacinasComponent implements OnInit {

  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = ['id', 'nomeDaVacina', 'dicaDaVacina', 'acoes'];
  dataSource!: Vacina[];
  form!: FormGroup;
  submitted = false;
  bsModalRef!: BsModalRef;

  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    public vacinasService: VacinasService,
    private alertaService: AlertaDialogService,
    private modal: AlertaDialogService

  ) {
    this.vacinasService.get()
      .subscribe((data: Vacina[]) => {
        console.log(data);
        this.dataSource = data;
      });
  }

  ngOnInit(): void {

    this.form = this.fb.group({
      nomeDaVacina: [null, [Validators.required, Validators.maxLength(25)]],
      dicaDaVacina: [null, [Validators.maxLength(255)]]
    });
  }

  hasError(field: string) {
    return this.form.get(field)?.errors;
  }

  onSubmit() {
    this.submitted = true;
    console.log(this.form.value);
    if (this.form.valid) {
      console.log('Botão funcionando');
      this.vacinasService.create(this.form.value).subscribe(
        success => this.modal.showAlertSuccess('Vacina cadastrada com sucesso.'),
        error => this.modal.showAlertDanger('Erro ao cadastrar vacina, verifique todos os campos.'),
        () => console.log('request completo')
      );
    }

  }

  openDialog(vacina: Vacina | null): void {
    const dialogRef = this.dialog.open(ElementDialogComponent, {
      width: '250px',
      data: vacina === null ? {
        id: null,
        nomeDaVacina: '',
        dicaDaVacina: ''
      } : {
        id: vacina.id,
        nomeDaVacina: vacina.nomeDaVacina,
        dicaDaVacina: vacina.dicaDaVacina
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        console.log(result);
        if (this.dataSource.map(p => p.id).includes(result.id)) {
          this.vacinasService.edit(result)
            .subscribe((data: Vacina) => {
              const index = this.dataSource.findIndex(p => p.id === data.id);
              this.dataSource[index] = data;
              this.table.renderRows();
            });
        } else {
          this.vacinasService.create(result)
            .subscribe((data: Vacina) => {
              this.dataSource.push(data);
              this.table.renderRows();
            });
        }
      }
    });
  }

  editElement(vacina: Vacina): void {
    this.openDialog(vacina);
  }

  deleteElement(id: number): void {
    this.vacinasService.delete(id)
      .subscribe(() => {
        this.dataSource = this.dataSource.filter(p => p.id !== id);
      });

  };

  handleError() {
    this.alertaService.showAlertDanger;
  }

}
