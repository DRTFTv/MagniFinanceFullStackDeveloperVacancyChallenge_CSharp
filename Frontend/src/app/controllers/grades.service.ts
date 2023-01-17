import { GradeAdd, GradeUpdate } from 'src/app/models/grades';
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

  add(Grade: GradeAdd): Observable<GradeAdd> {
    const apiURL = `${this.globalService.URL}/Grades/Add`;

    return this.http
      .post<GradeAdd>(apiURL, Grade)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getAll(): Observable<Grades[]> {
    const apiURL = `${this.globalService.URL}/Grades/GetAll`;

    return this.http
      .get<Grades[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getById(Id: number): Observable<Grades> {
    const apiURL = `${this.globalService.URL}/Grades/GetById/${Id}`;

    return this.http
      .get<Grades>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateById(Grade: GradeUpdate): Observable<Grades> {
    const apiURL = `${this.globalService.URL}/Grades/UpdateById`;

    return this.http
      .put<Grades>(apiURL, Grade, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Grades> {
    const apiURL = `${this.globalService.URL}/Grades/DeleteById/${Id}`;

    return this.http
      .delete<Grades>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
