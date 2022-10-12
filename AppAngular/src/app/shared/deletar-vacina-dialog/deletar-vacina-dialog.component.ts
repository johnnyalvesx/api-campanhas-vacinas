import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-deletar-vacina-dialog',
  templateUrl: './deletar-vacina-dialog.component.html',
  styleUrls: ['./deletar-vacina-dialog.component.scss']
})
export class DeletarVacinaDialogComponent implements OnInit {

  constructor(
    public dialog: MatDialog,

  ) { }

  ngOnInit(): void {
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
    this.dialog.open(DeletarVacinaDialogComponent, {
      width: '250px',
      enterAnimationDuration,
      exitAnimationDuration,
    });

  }
}
