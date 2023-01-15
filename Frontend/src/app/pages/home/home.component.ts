import { CoursesService } from './../../controllers/courses.service';
import { Courses } from './../../models/courses';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  allCourses: Observable<Courses[]> | undefined;

  constructor(private coursesService: CoursesService) {}

  ngOnInit() {
    this.listAll();
  }

  listAll() {
    this.coursesService.listAll().subscribe((data: any) => {
      console.warn(data);
    });
    console.warn(this.coursesService.getById(1));
    console.warn(this.allCourses);
  }
}
