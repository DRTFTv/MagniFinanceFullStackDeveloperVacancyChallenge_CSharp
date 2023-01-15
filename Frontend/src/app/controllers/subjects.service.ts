import { Subjects } from './../models/subjects';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry } from 'rxjs';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root',
})
export class SubjectsService {
  constructor(private http: HttpClient, private globalService: GlobalService) {}

  add(Subjects: Subjects): Observable<Subjects> {
    const apiURL = `${this.globalService.URL}/Add`;
    return this.http
      .post<Subjects>(apiURL, Subjects)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  listAll(): Observable<Subjects[]> {
    const apiURL = `${this.globalService.URL}/ListAll`;
    return this.http
      .get<Subjects[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getById(Id: number): Observable<Subjects> {
    const apiURL = `${this.globalService.URL}/GetById/${Id}`;

    return this.http
      .get<Subjects>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateById(Subjects: Subjects): Observable<Subjects> {
    const apiURL = `${this.globalService.URL}/UpdateById`;

    return this.http
      .put<Subjects>(apiURL, Subjects, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Subjects> {
    const apiURL = `${this.globalService.URL}/DeleteById/${Id}`;

    return this.http
      .delete<Subjects>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
