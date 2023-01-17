import { GradeUpdate } from './../../models/grades';
import { GradesService } from './../../controllers/grades.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GradeAdd, Grades } from 'src/app/models/grades';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.scss'],
})
export class GradesComponent {
  formGroup!: FormGroup;

  allGrades!: Grades[];
  copyEdit: any;
  interval: any;

  inCreation = false;
  inEdit = false;

  constructor(
    private formBuilder: FormBuilder,
    private gradesService: GradesService
  ) {}

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      gradeOne: ['', [Validators.required, Validators.maxLength(255)]],
      gradeTwo: ['', [Validators.required, Validators.maxLength(255)]],
      gradeThree: ['', [Validators.required, Validators.maxLength(255)]],
      gradeFour: ['', [Validators.required, Validators.maxLength(255)]],
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

  add() {
    this.gradesService
      .add(
        new GradeAdd(
          this.formGroup.controls['gradeOne'].value,
          this.formGroup.controls['gradeTwo'].value,
          this.formGroup.controls['gradeThree'].value,
          this.formGroup.controls['gradeFour'].value
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchCreation();
      });
  }

  getAll() {
    this.gradesService.getAll().subscribe((res) => {
      this.allGrades = res;
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
        this.getAll();
        this.switchEdit(null);
      });
  }

  delete(Id: number) {
    this.gradesService.deleteById(Id).subscribe(() => {
      this.getAll();
    });
  }
}
