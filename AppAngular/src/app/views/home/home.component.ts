import { ElementDialogComponent } from './../../shared/element-dialog/element-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';

export interface PeriodicElement {
  vacinaId: number;
  nomeDaVacina: string;
  dicaDaVacina: string;
  acoes: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { vacinaId: 1, nomeDaVacina: 'Hydrogen', dicaDaVacina: '1.0079', acoes: 'H' },
  { vacinaId: 2, nomeDaVacina: 'Helium', dicaDaVacina: '4.0026', acoes: 'He' },
  { vacinaId: 3, nomeDaVacina: 'Lithium', dicaDaVacina: '6.941', acoes: 'Li' },
  { vacinaId: 4, nomeDaVacina: 'Beryllium', dicaDaVacina: '9.0122', acoes: 'Be' },
  { vacinaId: 5, nomeDaVacina: 'Boron', dicaDaVacina: '10.811', acoes: 'B' },
  { vacinaId: 6, nomeDaVacina: 'Carbon', dicaDaVacina: '12.0107', acoes: 'C' },
  { vacinaId: 7, nomeDaVacina: 'Nitrogen', dicaDaVacina: '14.0067', acoes: 'N' },
  { vacinaId: 8, nomeDaVacina: 'Oxygen', dicaDaVacina: '15.9994', acoes: 'O' },
  { vacinaId: 9, nomeDaVacina: 'Fluorine', dicaDaVacina: '18.9984', acoes: 'F' },
  { vacinaId: 10, nomeDaVacina: 'Neon', dicaDaVacina: '20.1797', acoes: 'Ne' },
];


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild(MatTable)
  table!: MatTable<any>;
  displayedColumns: string[] = ['vacinaId', 'nomeDaVacina', 'dicaDaVacina', 'acoes'];
  dataSource = ELEMENT_DATA;

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {

  }

  openDialog(element: PeriodicElement | null): void {
    const dialogRef = this.dialog.open(ElementDialogComponent, {
      width: '250px',
      data: element === null ? {
        vacinaId: null,
        nomeDaVacina: '',
        dicaDaVacina: '',
        acoes: ''
      } : element
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        this.dataSource.push(result);
        this.table.renderRows();
      }

    });
  }

}
