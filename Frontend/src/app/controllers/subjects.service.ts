import { Subjects, SubjectsHome } from './../models/subjects';
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
    const apiURL = `${this.globalService.URL}/Subjects/Add`;

    return this.http
      .post<Subjects>(apiURL, Subjects)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getAll(): Observable<Subjects[]> {
    const apiURL = `${this.globalService.URL}/Subjects/GetAll`;

    return this.http
      .get<Subjects[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  homeGetAll(): Observable<SubjectsHome[]> {
    const apiURL = `${this.globalService.URL}/Subjects/HomeGetAll`;

    return this.http
      .get<SubjectsHome[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getById(Id: number): Observable<Subjects> {
    const apiURL = `${this.globalService.URL}/Subjects/GetById/${Id}`;

    return this.http
      .get<Subjects>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateById(Subjects: Subjects): Observable<Subjects> {
    const apiURL = `${this.globalService.URL}/Subjects/UpdateById`;

    return this.http
      .put<Subjects>(apiURL, Subjects, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteById(Id: number): Observable<Subjects> {
    const apiURL = `${this.globalService.URL}/Subjects/DeleteById/${Id}`;

    return this.http
      .delete<Subjects>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
