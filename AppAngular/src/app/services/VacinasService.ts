
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vacina } from '../models/Vacina';

@Injectable()
export class VacinasService {
  vacinasUrl = 'https://localhost:7279/api/vacinas';

  constructor(private http: HttpClient) { }

  getElements(): Observable<Vacina[]> {
    return this.http.get<Vacina[]>(this.vacinasUrl)
  }

  createElements(element: Vacina): Observable<Vacina> {
    return this.http.post<Vacina>(this.vacinasUrl, element);
  }

  editElement(element: Vacina): Observable<Vacina> {
    return this.http.put<Vacina>(this.vacinasUrl, element);
  }

  deleteElement(id: number): Observable<any> {
    return this.http.delete<any>(`${this.vacinasUrl}/${id}`);
  }
}
