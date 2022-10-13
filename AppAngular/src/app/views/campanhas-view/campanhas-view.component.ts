import { EditarCampanhaComponent } from './../../shared/editar-campanha/editar-campanha.component';
import { DatepickerComponent } from './../../shared/datepicker/datepicker.component';
import { CampanhasService } from './../../services/CampanhasService';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Campanha } from 'src/app/models/Campanha';
import { AlertaDialogService } from 'src/app/shared/alerta-dialog.service';
import { DeletarVacinaDialogComponent } from 'src/app/shared/deletar-vacina-dialog/deletar-vacina-dialog.component';
import { ElementDialogComponent } from 'src/app/shared/element-dialog/element-dialog.component';

@Component({
  selector: 'app-campanhas-view',
  templateUrl: './campanhas-view.component.html',
  styleUrls: ['./campanhas-view.component.scss'],
  providers: [CampanhasService, DatepickerComponent]
})
export class CampanhasViewComponent implements OnInit {

  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = ['id', 'nomeDaCampanha', 'data', 'statusDaCampanha', 'nomeDaVacina', 'acoes'];
  dataSource!: Campanha[];
  form!: FormGroup;
  submitted = false;
  bsModalRef!: BsModalRef;
  campanha!: Campanha;

  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    public campanhasService: CampanhasService,
    private alertaService: AlertaDialogService,
    private modal: AlertaDialogService,

  ) {
    this.campanhasService.get()
      .subscribe((data: Campanha[]) => {
        console.log(data);
        this.dataSource = data;
      });
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      nomeDaCampanha: [null, []],
      dataDeInicio: [null, []],
      dataDeTermino: [null, []],
      statusDaCampanha: [null, []],
      // nomeDaVacina: [null, []]
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
      this.campanhasService.create(this.form.value).subscribe(
        success => this.modal.showAlertSuccess('Vacina cadastrada com sucesso.'),
        error => this.modal.showAlertDanger('Erro ao cadastrar vacina, verifique todos os campos.'),
        () => console.log('request completo')
      );
    }
  }

  openDialog(campanha: Campanha | null, enterAnimationDuration?: string, exitAnimationDuration?: string,): void {
    const dialogRef = this.dialog.open(EditarCampanhaComponent, {
      width: '300px',
      enterAnimationDuration: "500ms",
      exitAnimationDuration: "500ms",
      data: campanha === null ? {
        id: null,
        nomeDaCampanha: '',
        dataDeInicio: null,
        dataDeTermino: null,
        statusDaCampanha: '',
        nomeDaVacina: ''
      } : {
        id: campanha.id,
        nomeDaCampanha: campanha.nomeDaCampanha,
        dataDeInicio: campanha.dataDeInicio,
        dataDeTermino: campanha.dataDeTermino,
        statusDaCampanha: campanha.statusDaCampanha,
        // nomeDaVacina: campanha.nomeDaVacina
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        console.log(result);
        if (this.dataSource.map(p => p.id).includes(result.id)) {
          this.campanhasService.edit(result)
            .subscribe((data: Campanha) => {
              const index = this.dataSource.findIndex(p => p.id === data.id);
              this.dataSource[index] = data;
              this.table.renderRows();
            });
        } else {
          this.campanhasService.create(result)
            .subscribe((data: Campanha) => {
              this.dataSource.push(data);
              this.table.renderRows();
            });
        }
      }
    });
  }

  editCampanha(campanha: Campanha): void {
    this.openDialog(campanha);
  }

  deleteCampanha(id: number): void {
    const dialogRef = this.dialog.open(DeletarVacinaDialogComponent, {
      width: '300px',
      data: 'Tem certeza? (vacinas component)'
    });
    dialogRef.afterClosed().subscribe(res => {

      if (res) {
        this.campanhasService.delete(id)
          .subscribe(() => {
            this.dataSource = this.dataSource.filter(p => p.id !== id);
          });
      }
    });
  }

  handleError() {
    this.alertaService.showAlertDanger;
  }

}
