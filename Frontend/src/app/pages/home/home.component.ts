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
export class HomeComponent implements OnInit {
  allCourses!: CoursesHome[];
  allSubjects!: SubjectsHome[];
  allStudents!: StudentsHome[];

  constructor(
    private coursesService: CoursesService,
    private subjectsService: SubjectsService,
    private studentsService: StudentsService
  ) {}

  ngOnInit() {
    this.getALL();
  }

  getALL() {
    this.coursesService.homeGetAll().subscribe((res) => {
      this.allCourses = res;
    });
    this.subjectsService.homeGetAll().subscribe((res) => {
      this.allSubjects = res;
    });
    this.studentsService.homeGetAll().subscribe((res) => {
      console.warn(res);
      this.allStudents = res;
    });
  }
}
