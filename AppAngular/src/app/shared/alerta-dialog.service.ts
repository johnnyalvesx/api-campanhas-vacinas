import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Injectable } from '@angular/core';
import { AlertaDialogComponent } from './alerta-dialog/alerta-dialog.component';

export enum AlertTypes {
  DANGER = 'danger',
  SUCCESS = 'success'
}

@Injectable({
  providedIn: 'root'
})
export class AlertaDialogService {

  constructor(private modalService: BsModalService) { }

  private showAlert(message: string, type: AlertTypes) {
    const bsModalRef: BsModalRef = this.modalService.show(AlertaDialogComponent);
    bsModalRef.content.type = type;
    bsModalRef.content.message = message;
  }

  showAlertDanger(message: string) {
    this.showAlert(message, AlertTypes.DANGER);
  }
  showAlertSuccess(message: string) {
    this.showAlert(message, AlertTypes.SUCCESS);
  }
}
