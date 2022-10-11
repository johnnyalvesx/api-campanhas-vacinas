import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Vacina } from 'src/app/models/Vacina';

@Component({
  selector: 'app-element-dialog',
  templateUrl: './element-dialog.component.html',
  styleUrls: ['./element-dialog.component.scss']
})
export class ElementDialogComponent implements OnInit {
  element!: Vacina;
  isChange!: boolean;

  constructor(
    @Inject(MAT_DIALOG_DATA)
    public data: Vacina,
    public dialogRef: MatDialogRef<ElementDialogComponent>,
  ) { }


  ngOnInit(): void {
    if (this.data.id != null) {
      this.isChange = true;
    } else {
      this.isChange = false;
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}
