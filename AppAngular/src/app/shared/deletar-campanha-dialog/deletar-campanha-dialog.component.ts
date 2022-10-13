import { Campanha } from 'src/app/models/Campanha';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Vacina } from 'src/app/models/Vacina';

@Component({
  selector: 'app-deletar-campanha-dialog',
  templateUrl: './deletar-campanha-dialog.component.html',
  styleUrls: ['./deletar-campanha-dialog.component.scss']
})
export class DeletarCampanhaDialogComponent implements OnInit {


  campanha!: Campanha;
  dataSource!: Vacina[];

  constructor(
    public dialogRef: MatDialogRef<DeletarCampanhaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public message: string) { }

  ngOnInit(): void {
  }

  onConfirmDelete() {

  }
}
