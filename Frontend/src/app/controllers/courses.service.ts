import { Courses } from './../models/courses';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
var httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  headers = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Accept', '*/*');

  URL = 'https://localhost:8080/api/Courses';

  constructor(private http: HttpClient) {}

  add(Courses: Courses): Observable<Courses> {
    const apiURL = `${this.URL}/Add`;
    return this.http.post<Courses>(apiURL, Courses);
  }

  listAll(): Observable<Courses[]> {
    const apiURL = `${this.URL}/ListAll`;

    return this.http.get<Courses[]>(apiURL, { headers: this.headers });
  }

  getById(Id: number): Observable<Courses> {
    const apiURL = `${this.URL}/GetById?Id=${Id}`;

    return this.http.get<Courses>(apiURL, httpOptions);
  }

  updateById(Courses: Courses): Observable<Courses> {
    const apiURL = `${this.URL}/UpdateById`;

    return this.http.put<Courses>(apiURL, Courses, httpOptions);
  }

  deleteById(Id: number): Observable<Courses> {
    const apiURL = `${this.URL}/DeleteById?Id=${Id}`;

    return this.http.delete<Courses>(apiURL, httpOptions);
  }
}
