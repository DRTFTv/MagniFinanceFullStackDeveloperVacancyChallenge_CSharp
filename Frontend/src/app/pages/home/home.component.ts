import { StudentsService } from './../../controllers/students.service';
import { StudentsHome } from './../../models/students';
import { SubjectsService } from './../../controllers/subjects.service';
import { SubjectsHome } from './../../models/subjects';
import { CoursesService } from './../../controllers/courses.service';
import { CoursesHome } from './../../models/courses';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  allCourses!: CoursesHome[];
  allSubjects!: SubjectsHome[];
  allStudents!: StudentsHome[];
  interval: any;

  constructor(
    private coursesService: CoursesService,
    private subjectsService: SubjectsService,
    private studentsService: StudentsService
  ) {}

  ngOnInit() {
    this.getAll();
    this.interval = setInterval(() => {
      this.getAll();
    }, 60000);
  }

  getAll() {
    this.coursesService.homeGetAll().subscribe((res) => {
      this.allCourses = res;
    });
    this.subjectsService.homeGetAll().subscribe((res) => {
      this.allSubjects = res;
    });
    this.studentsService.homeGetAll().subscribe((res) => {
      this.allStudents = res;
    });
  }
}
