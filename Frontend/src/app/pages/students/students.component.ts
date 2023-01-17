import { StudentAdd, StudentUpdate } from './../../models/students';
import { formatDate } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StudentsService } from 'src/app/controllers/students.service';
import { Students } from 'src/app/models/students';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.scss'],
})
export class StudentsComponent {
  formGroup!: FormGroup;

  allStudents!: Students[];
  copyEdit: any;
  interval: any;

  inCreation = false;
  inEdit = false;

  constructor(
    private formBuilder: FormBuilder,
    private studentsService: StudentsService
  ) {}

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(255)]],
      birthDate: [
        formatDate(new Date(), 'yyyy-MM-dd', 'en'),
        [Validators.required],
      ],
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

  switchEdit(Student: any) {
    this.inCreation = false;

    if (this.copyEdit == null && Student != null) {
      this.formGroup.reset();
      this.inEdit = true;
      this.copyEdit = Student;
      this.formGroup.controls['name'].setValue(this.copyEdit.name);
      this.formGroup.controls['birthDate'].setValue(
        formatDate(this.copyEdit.birthDate, 'yyyy-MM-dd', 'en')
      );
    } else {
      this.formGroup.reset();
      this.inEdit = false;
      this.copyEdit = null;
    }
  }

  add() {
    this.studentsService
      .add(
        new StudentAdd(
          this.formGroup.controls['name'].value,
          new Date(this.formGroup.controls['birthDate'].value)
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchCreation();
      });
  }

  getAll() {
    this.studentsService.getAll().subscribe((res) => {
      this.allStudents = res;
    });
  }

  edit() {
    this.studentsService
      .updateById(
        new StudentUpdate(
          this.copyEdit.id,
          this.formGroup.controls['name'].value,
          new Date(this.formGroup.controls['birthDate'].value)
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchEdit(null);
      });
  }

  delete(Id: number) {
    this.studentsService.deleteById(Id).subscribe(() => {
      this.getAll();
    });
  }
}
