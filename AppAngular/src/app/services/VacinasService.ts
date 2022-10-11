
import { Observable, take } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vacina } from '../models/Vacina';

@Injectable()
export class VacinasService {
  vacinasUrl = 'https://localhost:7279/api/vacinas';

  constructor(private http: HttpClient) { }

  get(): Observable<Vacina[]> {
    return this.http.get<Vacina[]>(this.vacinasUrl)
  }

  create(vacina: Vacina): Observable<Vacina> {
    return this.http.post<Vacina>(this.vacinasUrl, vacina).pipe(take(2));
  }

  edit(vacina: Vacina): Observable<Vacina> {
    return this.http.put<Vacina>(this.vacinasUrl, vacina);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.vacinasUrl}/${id}`);
  }
}


