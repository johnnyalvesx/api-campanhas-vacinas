import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { VacinasService } from './vacinas.service';
import { VacinasComponent } from './components/vacinas/vacinas.component';

@NgModule({
  declarations: [
    AppComponent,
    VacinasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
  ],
  providers: [HttpClientModule, VacinasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
