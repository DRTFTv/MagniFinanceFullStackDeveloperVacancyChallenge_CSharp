import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GradesService } from 'src/app/controllers/grades.service';
import { Grades, GradeUpdate } from 'src/app/models/grades';

@Component({
  selector: 'app-grade-by-id',
  templateUrl: './grade-by-id.component.html',
  styleUrls: ['./grade-by-id.component.scss'],
})
export class GradeByIdComponent {
  formGroup!: FormGroup;

  grade!: Grades;
  copyEdit: any;
  interval: any;

  inEdit = false;

  constructor(
    private formBuilder: FormBuilder,
    private gradesService: GradesService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      gradeOne: ['', [Validators.required]],
      gradeTwo: ['', [Validators.required]],
      gradeThree: ['', [Validators.required]],
      gradeFour: ['', [Validators.required]],
    });

    this.get();
    this.interval = setInterval(() => {
      this.get();
    }, 60000);
  }

  switchEdit(Course: any) {
    if (this.copyEdit == null && Course != null) {
      this.formGroup.reset();
      this.inEdit = true;
      this.copyEdit = Course;
      this.formGroup.controls['gradeOne'].setValue(this.copyEdit.gradeOne);
      this.formGroup.controls['gradeTwo'].setValue(this.copyEdit.gradeTwo);
      this.formGroup.controls['gradeThree'].setValue(this.copyEdit.gradeThree);
      this.formGroup.controls['gradeFour'].setValue(this.copyEdit.gradeFour);
    } else {
      this.formGroup.reset();
      this.inEdit = false;
      this.copyEdit = null;
    }
  }

  get() {
    this.gradesService
      .getById(this.route.snapshot.params['id'])
      .subscribe((res) => {
        this.grade = res;
      });
  }

  edit() {
    this.gradesService
      .updateById(
        new GradeUpdate(
          this.copyEdit.id,
          this.formGroup.controls['gradeOne'].value,
          this.formGroup.controls['gradeTwo'].value,
          this.formGroup.controls['gradeThree'].value,
          this.formGroup.controls['gradeFour'].value
        )
      )
      .subscribe(() => {
        this.get();
        this.switchEdit(null);
      });
  }

  returnEnrollment() {
    this.router.navigate(['/enrollments']);
  }
}
