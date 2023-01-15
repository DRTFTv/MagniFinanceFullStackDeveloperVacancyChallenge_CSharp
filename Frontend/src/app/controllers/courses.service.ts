import { GlobalService } from './global.service';
import { Courses } from './../models/courses';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  constructor(private http: HttpClient, private globalService: GlobalService) {}

  add(Courses: Courses): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/Add`;
    return this.http
      .post<Courses>(apiURL, Courses)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  listAll(): Observable<Courses[]> {
    const apiURL = `${this.globalService.URL}/ListAll`;
    return this.http
      .get<Courses[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getById(Id: number): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/GetById/${Id}`;

    return this.http
      .get<Courses>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateById(Courses: Courses): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/UpdateById`;

    return this.http
      .put<Courses>(apiURL, Courses, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/DeleteById/${Id}`;

    return this.http
      .delete<Courses>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
