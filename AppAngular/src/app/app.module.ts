import { VacinasComponent } from './views/vacinas/vacinas.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';

import { HeaderComponent } from './shared/header/header.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { ElementDialogComponent } from './shared/element-dialog/element-dialog.component';
import { FormsModule } from '@angular/forms';
import { AlertaDialogComponent } from './shared/alerta-dialog/alerta-dialog.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { DeletarVacinaDialogComponent } from './shared/deletar-vacina-dialog/deletar-vacina-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    VacinasComponent,
    HeaderComponent,
    ElementDialogComponent,
    AlertaDialogComponent,
    DeletarVacinaDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    FlexLayoutModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatDialogModule,
    FormsModule,
    ModalModule.forRoot()
  ],
  entryComponents: [DeletarVacinaDialogComponent],
  providers: [HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
