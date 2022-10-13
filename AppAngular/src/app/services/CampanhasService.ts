import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject, take, tap } from "rxjs";
import { Campanha } from "../models/Campanha";

@Injectable()
export class CampanhasService {
  campanhasUrl = 'https://localhost:7279/api/campanhas';

  constructor(private http: HttpClient) { }

  private _refreshNeeded$ = new Subject<void>;

  get refreshNeeded() {
    return this._refreshNeeded$;
  }

  public get(): Observable<Campanha[]> {
    return this.http.get<Campanha[]>(this.campanhasUrl)
  }

  public create(campanha: Campanha): Observable<Campanha> {
    return this.http.post<Campanha>(this.campanhasUrl, campanha)
      .pipe(
        tap(() => {
          this._refreshNeeded$.next();
        })
      );
  }

  public edit(campanha: Campanha): Observable<Campanha> {
    return this.http.put<Campanha>(this.campanhasUrl, campanha);
  }

  public delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.campanhasUrl}/${id}`).pipe(take(1));
  }
}
