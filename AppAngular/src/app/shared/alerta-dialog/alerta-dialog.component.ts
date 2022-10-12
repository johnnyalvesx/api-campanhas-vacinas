import { BsModalRef } from 'ngx-bootstrap/modal';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-alerta-dialog',
  templateUrl: './alerta-dialog.component.html',
  styleUrls: ['./alerta-dialog.component.scss']
})
export class AlertaDialogComponent implements OnInit {

  @Input() type = 'success';
  @Input() message!: string;


  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  onClose():void {
    this.bsModalRef.hide();
  }
}
