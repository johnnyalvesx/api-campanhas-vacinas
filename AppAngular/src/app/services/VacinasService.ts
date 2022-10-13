
import { Observable, Subject, take, tap } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Vacina } from '../models/Vacina';

@Injectable()
export class VacinasService {
  vacinasUrl = 'https://localhost:7279/api/vacinas';

  constructor(private http: HttpClient) { }

  private _refreshNeeded$ = new Subject<void>;

  get refreshNeeded() {
    return this._refreshNeeded$;
  }

  public get(): Observable<Vacina[]> {
    return this.http.get<Vacina[]>(this.vacinasUrl);
  }

  public create(vacina: Vacina): Observable<Vacina> {
    return this.http.post<Vacina>(this.vacinasUrl, vacina)
      .pipe(
        tap(() => {
          this._refreshNeeded$.next();
        })
      );
  }

  public edit(vacina: Vacina): Observable<Vacina> {
    return this.http.put<Vacina>(this.vacinasUrl, vacina);
  }

  public delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.vacinasUrl}/${id}`).pipe(take(1));
  }
}


