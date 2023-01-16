import { CoursesComponent } from './pages/courses/courses.component';
import { TeachersComponent } from './pages/teachers/teachers.component';
import { StudentsComponent } from './pages/students/students.component';
import { HomeComponent } from './pages/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, title: 'Home' },
  { path: 'students', component: StudentsComponent, title: 'Students' },
  { path: 'teachers', component: TeachersComponent, title: 'Teachers' },
  { path: 'courses', component: CoursesComponent, title: 'Courses' },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
