import { VacinasService } from './../../services/VacinasService';
import { ElementDialogComponent } from './../../shared/element-dialog/element-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { PeriodicElement } from 'src/app/models/PeriodicElement';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [VacinasService]
})
export class HomeComponent implements OnInit {
  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = ['vacinaId', 'nomeDaVacina', 'dicaDaVacina', 'acoes'];
  dataSource!: PeriodicElement[];

  constructor(
    public dialog: MatDialog,
    public vacinasService: VacinasService
  ) {
    this.vacinasService.getElements()
      .subscribe((data: PeriodicElement[]) => {
        console.log(data);
        this.dataSource = data;
      });
  }

  ngOnInit(): void {

  }

  openDialog(element: PeriodicElement | null): void {
    const dialogRef = this.dialog.open(ElementDialogComponent, {
      width: '250px',
      data: element === null ? {
        position: null,
        nomeDaVacina: '',
        dicaDaVacina: '',
        acoes: ''
      } : {
        vacinaId: element.vacinaId,
        position: element.position,
        nomeDaVacina: element.nomeDaVacina,
        dicaDaVacina: element.dicaDaVacina,
        acoes: element.acoes
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        console.log(result);
        if (this.dataSource.map(p => p.vacinaId).includes(result.id)) {
          this.vacinasService.editElement(result)
            .subscribe((data: PeriodicElement) => {
              const index = this.dataSource.findIndex(p => p.vacinaId === data.vacinaId);
              this.dataSource[index] = data;
              this.table.renderRows();
            });
        } else {
          this.vacinasService.createElements(result)
            .subscribe((data: PeriodicElement) => {
              this.dataSource.push(data);
              this.table.renderRows();
            });
        }
      }
    });
  }

  editElement(element: PeriodicElement): void {
    this.openDialog(element);
  }

  deleteElement(position: number): void {
    this.vacinasService.deleteElement(position)
      .subscribe(() => {
        this.dataSource = this.dataSource.filter(p => p.vacinaId !== position);
      });

  };
}
