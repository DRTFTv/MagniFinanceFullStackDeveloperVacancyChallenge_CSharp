import { GlobalService } from './global.service';
import {
  Courses,
  CoursesHome,
  CourseAdd,
  CourseUpdate,
} from './../models/courses';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, retry, catchError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  constructor(private http: HttpClient, private globalService: GlobalService) {}

  add(Course: CourseAdd): Observable<CourseAdd> {
    const apiURL = `${this.globalService.URL}/Courses/Add`;

    return this.http
      .post<CourseAdd>(apiURL, Course)
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

  updateById(Course: CourseUpdate): Observable<CourseUpdate> {
    const apiURL = `${this.globalService.URL}/Courses/UpdateById`;

    return this.http
      .put<CourseUpdate>(apiURL, Course, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Courses> {
    const apiURL = `${this.globalService.URL}/Courses/DeleteById/${Id}`;

    return this.http
      .delete<Courses>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
