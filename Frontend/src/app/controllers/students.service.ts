import {
  Students,
  StudentsHome,
  StudentAdd,
  StudentUpdate,
} from './../models/students';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry } from 'rxjs';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  constructor(private http: HttpClient, private globalService: GlobalService) {}

  add(Student: StudentAdd): Observable<StudentAdd> {
    const apiURL = `${this.globalService.URL}/Students/Add`;

    return this.http
      .post<StudentAdd>(apiURL, Student)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getAll(): Observable<Students[]> {
    const apiURL = `${this.globalService.URL}/Students/GetAll`;

    return this.http
      .get<Students[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  homeGetAll(): Observable<StudentsHome[]> {
    const apiURL = `${this.globalService.URL}/Students/HomeGetAll`;

    return this.http
      .get<StudentsHome[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getById(Id: number): Observable<Students> {
    const apiURL = `${this.globalService.URL}/Students/GetById/${Id}`;

    return this.http
      .get<Students>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateById(Student: StudentUpdate): Observable<StudentUpdate> {
    const apiURL = `${this.globalService.URL}/Students/UpdateById`;

    return this.http
      .put<StudentUpdate>(apiURL, Student)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Students> {
    const apiURL = `${this.globalService.URL}/Students/DeleteById/${Id}`;

    return this.http
      .delete<Students>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
