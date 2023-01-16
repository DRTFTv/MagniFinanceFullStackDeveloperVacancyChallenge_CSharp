import { CoursesService } from './../../controllers/courses.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Courses, CourseAdd, CourseUpdate } from './../../models/courses';
import { Component } from '@angular/core';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss'],
})
export class CoursesComponent {
  formGroup!: FormGroup;

  allCourses!: Courses[];
  copyEdit: any;
  interval: any;

  inCreation = false;
  inEdit = false;

  constructor(
    private formBuilder: FormBuilder,
    private coursesService: CoursesService
  ) {}

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(255)]],
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
  }

  switchEdit(Course: any) {
    this.inCreation = false;

    if (this.copyEdit == null && Course != null) {
      this.formGroup.reset();
      this.inEdit = true;
      this.copyEdit = Course;
      this.formGroup.controls['name'].setValue(this.copyEdit.name);
    } else {
      this.formGroup.reset();
      this.inEdit = false;
      this.copyEdit = null;
    }
  }

  add() {
    this.coursesService
      .add(new CourseAdd(this.formGroup.controls['name'].value))
      .subscribe(() => {
        this.getAll();
        this.switchCreation();
      });
  }

  getAll() {
    this.coursesService.getAll().subscribe((res) => {
      this.allCourses = res;
    });
  }

  edit() {
    this.coursesService
      .updateById(
        new CourseUpdate(
          this.copyEdit.id,
          this.formGroup.controls['name'].value
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchEdit(null);
      });
  }

  delete(Id: number) {
    this.coursesService.deleteById(Id).subscribe(() => {
      this.getAll();
    });
  }
}
