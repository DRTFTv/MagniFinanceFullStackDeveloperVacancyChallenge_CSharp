import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry } from 'rxjs';
import {
  EnrollmentAdd,
  Enrollments,
  EnrollmentsGetAll,
  EnrollmentUpdate,
} from '../models/enrollments';
import { GlobalService } from './global.service';

@Injectable({
  providedIn: 'root',
})
export class EnrollmentsService {
  constructor(private http: HttpClient, private globalService: GlobalService) {}

  add(Enrollment: EnrollmentAdd): Observable<EnrollmentAdd> {
    const apiURL = `${this.globalService.URL}/Enrollments/Add`;

    return this.http
      .post<EnrollmentAdd>(apiURL, Enrollment)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getAll(): Observable<EnrollmentsGetAll[]> {
    const apiURL = `${this.globalService.URL}/Enrollments/GetAll`;

    return this.http
      .get<EnrollmentsGetAll[]>(apiURL)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getByRegistrationNumber(RegistrationNumber: number): Observable<Enrollments> {
    const apiURL = `${this.globalService.URL}/Enrollments/GetByRegistrationNumber/${RegistrationNumber}`;

    return this.http
      .get<Enrollments>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  getAllByStudentId(StudentId: number): Observable<Enrollments[]> {
    const apiURL = `${this.globalService.URL}/Enrollments/GetAllByStudentId/${StudentId}`;

    return this.http
      .get<Enrollments[]>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  updateByRegistrationNumber(
    Enrollment: EnrollmentUpdate
  ): Observable<EnrollmentUpdate> {
    const apiURL = `${this.globalService.URL}/Enrollments/UpdateByRegistrationNumber`;

    return this.http
      .put<EnrollmentUpdate>(apiURL, Enrollment, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteByRegistrationNumber(
    RegistrationNumber: number
  ): Observable<Enrollments> {
    const apiURL = `${this.globalService.URL}/Enrollments/DeleteByRegistrationNumber/${RegistrationNumber}`;

    return this.http
      .delete<Enrollments>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }

  deleteByStudentId(StudentId: number): Observable<Enrollments> {
    const apiURL = `${this.globalService.URL}/Enrollments/DeleteByStudentId/${StudentId}`;

    return this.http
      .delete<Enrollments>(apiURL, this.globalService.httpOptions)
      .pipe(retry(1), catchError(this.globalService.errorHandler));
  }
}
