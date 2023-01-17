import { GradesService } from '../../../controllers/grades.service';
import { SubjectsService } from '../../../controllers/subjects.service';
import { StudentsService } from 'src/app/controllers/students.service';
import { Students } from 'src/app/models/students';
import { EnrollmentsService } from '../../../controllers/enrollments.service';
import {
  EnrollmentAdd,
  EnrollmentsGetAll,
  EnrollmentUpdate,
} from '../../../models/enrollments';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subjects } from 'src/app/models/subjects';
import { Router } from '@angular/router';

@Component({
  selector: 'app-enrollments',
  templateUrl: './enrollments.component.html',
  styleUrls: ['./enrollments.component.scss'],
})
export class EnrollmentsComponent {
  formGroup!: FormGroup;
  allStudents!: Students[];
  allSubjects!: Subjects[];

  allEnrollments!: EnrollmentsGetAll[];
  interval: any;

  inCreation = false;

  constructor(
    private formBuilder: FormBuilder,
    private enrollmentsService: EnrollmentsService,
    private studentsService: StudentsService,
    private subjectsService: SubjectsService,
    private router: Router
  ) {}

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      studentId: ['', [Validators.required]],
      subjectId: ['', [Validators.required]],
    });

    this.getAll();
    this.interval = setInterval(() => {
      this.getAll();
    }, 60000);
  }

  switchCreation() {
    this.formGroup.reset();
    this.inCreation = !this.inCreation;
    this.studentsGetAll();
    this.subjectsGetAll();
  }

  redirectEdit(GradeId: number) {
    this.router.navigate(['/grades/byid', GradeId]);
  }

  add() {
    this.enrollmentsService
      .add(
        new EnrollmentAdd(
          this.formGroup.controls['studentId'].value,
          this.formGroup.controls['subjectId'].value
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchCreation();
      });
  }

  getAll() {
    this.enrollmentsService.getAll().subscribe((res) => {
      this.allEnrollments = res;
    });
  }

  studentsGetAll() {
    this.studentsService.getAll().subscribe((res) => {
      this.allStudents = res;
    });
  }

  subjectsGetAll() {
    this.subjectsService.getAll().subscribe((res) => {
      this.allSubjects = res;
    });
  }

  delete(RegistrationNumber: number) {
    this.enrollmentsService
      .deleteByRegistrationNumber(RegistrationNumber)
      .subscribe(() => {
        this.getAll();
      });
  }
}
