import { Grades } from './../models/grades';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GlobalService } from './global.service';
import { catchError, Observable, retry } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GradesService {
  constructor(private http: HttpClient, private globalService: GlobalService) {}

  add(Grades: Grades): Observable<Grades> {
    const apiURL = `${this.globalService.URL}/Add`;
    return this.http
      .post<Grades>(apiURL, Grades)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  listAll(): Observable<Grades[]> {
    const apiURL = `${this.globalService.URL}/ListAll`;
    return this.http
      .get<Grades[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getById(Id: number): Observable<Grades> {
    const apiURL = `${this.globalService.URL}/GetById/${Id}`;

    return this.http
      .get<Grades>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateById(Grades: Grades): Observable<Grades> {
    const apiURL = `${this.globalService.URL}/UpdateById`;

    return this.http
      .put<Grades>(apiURL, Grades, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Grades> {
    const apiURL = `${this.globalService.URL}/DeleteById/${Id}`;

    return this.http
      .delete<Grades>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
