import { StudentsService } from './controllers/students.service';
import { RouterModule } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { StudentsComponent } from './pages/students/students.component';
import { ReactiveFormsModule } from '@angular/forms';
import { TeachersComponent } from './pages/teachers/teachers.component';
import { CoursesComponent } from './pages/courses/courses.component';
import { SubjectsComponent } from './pages/subjects/subjects.component';
import { GradesComponent } from './pages/grades/grades.component';
import { EnrollmentsComponent } from './pages/students/enrollments/enrollments.component';
import { GradeByIdComponent } from './pages/grades/grade-by-id/grade-by-id.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StudentsComponent,
    TeachersComponent,
    CoursesComponent,
    SubjectsComponent,
    GradesComponent,
    EnrollmentsComponent,
    GradeByIdComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
      defaultLanguage: 'pt',
    }),
  ],
  providers: [HttpClientModule, StudentsService],
  bootstrap: [AppComponent],
  exports: [RouterModule],
})
export class AppModule {}
