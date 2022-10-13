import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, take } from "rxjs";
import { Campanha } from "../models/Campanha";

@Injectable()
export class CampanhasService {
  vacinasUrl = 'https://localhost:7279/api/campanhas';

  constructor(private http: HttpClient) { }

  get(): Observable<Campanha[]> {
    return this.http.get<Campanha[]>(this.vacinasUrl)
  }

  create(vacina: Campanha): Observable<Campanha> {
    return this.http.post<Campanha>(this.vacinasUrl, vacina).pipe(take(2));
  }

  edit(vacina: Campanha): Observable<Campanha> {
    return this.http.put<Campanha>(this.vacinasUrl, vacina);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.vacinasUrl}/${id}`).pipe(take(1));
  }
}
