import { GlobalService } from './global.service';
import { Courses, CoursesHome } from './../models/courses';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  constructor(private http: HttpClient, private globalService: GlobalService) {}

  add(Courses: Courses): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/Courses/Add`;

    return this.http
      .post<Courses>(apiURL, Courses)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getAll(): Observable<Courses[]> {
    const apiURL = `${this.globalService.URL}/Courses/GetAll`;

    return this.http
      .get<Courses[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  homeGetAll(): Observable<CoursesHome[]> {
    const apiURL = `${this.globalService.URL}/Courses/HomeGetAll`;

    return this.http
      .get<CoursesHome[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getById(Id: number): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/Courses/GetById/${Id}`;

    return this.http
      .get<Courses>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateById(Courses: Courses): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/Courses/UpdateById`;

    return this.http
      .put<Courses>(apiURL, Courses, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/Courses/DeleteById/${Id}`;

    return this.http
      .delete<Courses>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
