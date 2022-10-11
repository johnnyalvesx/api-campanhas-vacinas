import { VacinasService } from './../../services/VacinasService';
import { ElementDialogComponent } from './../../shared/element-dialog/element-dialog.component';
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { Vacina } from 'src/app/models/Vacina';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [VacinasService]
})

export class HomeComponent implements OnInit {
  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = ['id', 'nomeDaVacina', 'dicaDaVacina', 'acoes'];
  dataSource!: Vacina[];


  constructor(

    public dialog: MatDialog,
    public vacinasService: VacinasService
  ) {
    this.vacinasService.getElements()
      .subscribe((data: Vacina[]) => {
        console.log(data);
        this.dataSource = data;
      });
  }

  ngOnInit(): void {

  }

  openDialog(element: Vacina | null): void {
    const dialogRef = this.dialog.open(ElementDialogComponent, {
      width: '250px',
      data: element === null ? {
        id: null,
        nomeDaVacina: '',
        dicaDaVacina: '',
        acoes: ''
      } : {
        id: element.id,
        nomeDaVacina: element.nomeDaVacina,
        dicaDaVacina: element.dicaDaVacina,
        acoes: element.acoes
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        console.log(result);
        if (this.dataSource.map(p => p.id).includes(result.id)) {
          this.vacinasService.editElement(result)
            .subscribe((data: Vacina) => {
              const index = this.dataSource.findIndex(p => p.id === data.id);
              this.dataSource[index] = data;
              this.table.renderRows();
            });
        } else {
          this.vacinasService.createElements(result)
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
    this.vacinasService.deleteElement(id)
      .subscribe(() => {
        this.dataSource = this.dataSource.filter(p => p.id !== id);
      });

  };
}
