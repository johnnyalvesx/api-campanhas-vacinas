import { Campanha } from 'src/app/models/Campanha';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-editar-campanha',
  templateUrl: './editar-campanha.component.html',
  styleUrls: ['./editar-campanha.component.scss']
})
export class EditarCampanhaComponent implements OnInit {

  element!: Campanha;

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: Campanha,
    public dialogRef: MatDialogRef<EditarCampanhaComponent>,
  ) { }

  ngOnInit(): void {

  }

  onCancel(): void {
    this.dialogRef.close();
  }

}
