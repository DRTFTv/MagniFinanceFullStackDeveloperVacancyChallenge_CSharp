import { Students } from './../models/students';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry } from 'rxjs';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  constructor(private http: HttpClient, private globalService: GlobalService) {}

  add(Students: Students): Observable<Students> {
    const apiURL = `${this.globalService.URL}/Add`;
    return this.http
      .post<Students>(apiURL, Students)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  listAll(): Observable<Students[]> {
    const apiURL = `${this.globalService.URL}/ListAll`;

    return this.http
      .get<Students[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getById(Id: number): Observable<Students> {
    const apiURL = `${this.globalService.URL}/GetById/${Id}`;

    return this.http
      .get<Students>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateById(Students: Students): Observable<Students> {
    const apiURL = `${this.globalService.URL}/UpdateById`;

    return this.http
      .put<Students>(apiURL, Students)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Students> {
    const apiURL = `${this.globalService.URL}/DeleteById/${Id}`;

    return this.http
      .delete<Students>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}