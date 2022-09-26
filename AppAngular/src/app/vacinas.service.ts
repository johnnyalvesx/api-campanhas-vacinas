import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Vacina } from './Vacina';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class VacinasService {
  url = 'https://localhost:5001/api/vacinas';

  constructor(private http: HttpClient) { }

  PegarTodasAsVacinas(): Observable<Vacina[]> {
    return this.http.get<Vacina[]>(this.url);
  }

  PegarVacinaPeloId(vacinaId: number): Observable<Vacina> {
    const apiUrl = `${this.url}/${vacinaId}`;
    return this.http.get<Vacina>(apiUrl);
  }

  SalvarVacina(vacina: Vacina): Observable<any> {
    return this.http.post<Vacina>(this.url, vacina, httpOptions);
  }

  AtualizarVacina(vacina: Vacina): Observable<any> {
    return this.http.put<Vacina>(this.url, vacina, httpOptions);
  }

  ExcluirVacina(vacinaId: Vacina): Observable<any> {
    const apiUrl = `${this.url}/${vacinaId}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
