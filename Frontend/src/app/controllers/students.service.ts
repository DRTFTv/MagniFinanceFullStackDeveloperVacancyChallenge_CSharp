import { Students } from './../models/students';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  URL = 'https://localhost:8080/api/';

  constructor(private http: HttpClient) {}

  add(Students: Students): Observable<Students> {
    const apiURL = `${this.URL}/Add`;
    return this.http.post<Students>(apiURL, Students);
  }

  listAll(): Observable<Students> {
    const apiURL = `${this.URL}/ListAll`;

    return this.http.get<Students>(apiURL);
  }

  getById(Id: number): Observable<Students> {
    const apiURL = `${this.URL}/GetById?Id=${Id}`;

    return this.http.get<Students>(apiURL);
  }

  updateById(Students: Students): Observable<Students> {
    const apiURL = `${this.URL}/UpdateById`;

    return this.http.put<Students>(apiURL, Students);
  }

  deleteById(Id: number): Observable<Students> {
    const apiURL = `${this.URL}/DeleteById?Id=${Id}`;

    return this.http.delete<Students>(apiURL);
  }
}
