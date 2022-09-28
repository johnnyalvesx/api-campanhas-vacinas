import { PeriodicElement } from './../views/home/home.component';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class VacinasService {
  elementApiUrl = 'http://localhost:4200/api/vacinas';
  constructor(private http: HttpClient) { }

  getElements(): Observable<PeriodicElement[]> {
    return this.http.get<PeriodicElement[]>(this.elementApiUrl)
  }

  createElements(vacina: PeriodicElement): Observable<PeriodicElement> {
    return this.http.post<PeriodicElement>(this.elementApiUrl, vacina);
  }

  editElement(element: PeriodicElement): Observable<PeriodicElement> {
    return this.http.put<PeriodicElement>(this.elementApiUrl, element);
  }

  deleteElement(id: number): Observable<any> {
    return this.http.delete<any>(`${this.elementApiUrl}/${id}`);
  }
}
