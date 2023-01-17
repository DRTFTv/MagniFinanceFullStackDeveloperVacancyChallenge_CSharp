import { Teachers } from './../../models/teachers';
import { Courses } from './../../models/courses';
import { TeachersService } from './../../controllers/teachers.service';
import { CoursesService } from './../../controllers/courses.service';
import { SubjectsService } from './../../controllers/subjects.service';
import {
  SubjectAdd,
  Subjects,
  SubjectUpdate,
  SubjectsGetAll,
} from './../../models/subjects';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.scss'],
})
export class SubjectsComponent {
  formGroup!: FormGroup;

  allSubjects!: SubjectsGetAll[];
  allCourses!: Courses[];
  allTeachers!: Teachers[];
  copyEdit: any;
  interval: any;

  inCreation = false;
  inEdit = false;

  constructor(
    private formBuilder: FormBuilder,
    private subjectsService: SubjectsService,
    private coursesService: CoursesService,
    private teachersService: TeachersService
  ) {}

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(255)]],
      courseId: ['', [Validators.required]],
      teacherId: ['', [Validators.required]],
    });

    this.getAll();
    this.interval = setInterval(() => {
      this.getAll();
    }, 60000);
  }

  switchCreation() {
    this.formGroup.reset();
    this.inCreation = !this.inCreation;
    this.inEdit = false;
    this.coursesGetAll();
    this.teachersGetAll();
  }

  switchEdit(Subject: any) {
    this.inCreation = false;

    if (this.copyEdit == null && Subject != null) {
      this.formGroup.reset();
      this.inEdit = true;
      this.copyEdit = Subject;
      console.warn(this.copyEdit);
      this.formGroup.controls['name'].setValue(this.copyEdit.name);
      this.formGroup.controls['courseId'].setValue(this.copyEdit.courseId);
      this.formGroup.controls['teacherId'].setValue(this.copyEdit.teacherId);
      this.coursesGetAll();
      this.teachersGetAll();
    } else {
      this.formGroup.reset();
      this.inEdit = false;
      this.copyEdit = null;
    }
  }

  add() {
    this.subjectsService
      .add(
        new SubjectAdd(
          this.formGroup.controls['name'].value,
          this.formGroup.controls['courseId'].value,
          this.formGroup.controls['teacherId'].value
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchCreation();
      });
  }

  getAll() {
    this.subjectsService.getAll().subscribe((res) => {
      this.allSubjects = res;
    });
  }

  coursesGetAll() {
    this.coursesService.getAll().subscribe((res) => {
      this.allCourses = res;
    });
  }

  teachersGetAll() {
    this.teachersService.getAll().subscribe((res) => {
      this.allTeachers = res;
    });
  }

  edit() {
    this.subjectsService
      .updateById(
        new SubjectUpdate(
          this.copyEdit.id,
          this.formGroup.controls['name'].value,
          this.formGroup.controls['courseId'].value,
          this.formGroup.controls['teacherId'].value
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchEdit(null);
      });
  }

  delete(Id: number) {
    this.subjectsService.deleteById(Id).subscribe(() => {
      this.getAll();
    });
  }
}
