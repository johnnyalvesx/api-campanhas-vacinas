import { VacinasService } from './../../services/VacinasService';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Vacina } from 'src/app/models/Vacina';
import { VacinasComponent } from 'src/app/views/vacinas/vacinas.component';

@Component({
  selector: 'app-deletar-vacina-dialog',
  templateUrl: './deletar-vacina-dialog.component.html',
  styleUrls: ['./deletar-vacina-dialog.component.scss'],
  providers: [VacinasService, VacinasService]
})
export class DeletarVacinaDialogComponent implements OnInit {

  vacina!: Vacina;
  dataSource!: Vacina[];

  constructor(
    public dialogRef: MatDialogRef<DeletarVacinaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public message: string) { }

  ngOnInit(): void {
  }

  onConfirmDelete() {

  }

}
