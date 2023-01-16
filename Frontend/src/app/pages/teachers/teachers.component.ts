import { TeachersService } from './../../controllers/teachers.service';
import { TeacherAdd, Teachers, TeacherUpdate } from './../../models/teachers';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.scss'],
})
export class TeachersComponent {
  formGroup!: FormGroup;

  allTeachers!: Teachers[];
  copyEdit: any;
  interval: any;

  inCreation = false;
  inEdit = false;

  constructor(
    private formBuilder: FormBuilder,
    private teachersService: TeachersService
  ) {}

  ngOnInit() {
    this.formGroup = this.formBuilder.group({
      name: ['', [Validators.required, Validators.maxLength(255)]],
      birthDate: [
        formatDate(new Date(), 'yyyy-MM-dd', 'en'),
        [Validators.required],
      ],
      salary: ['', [Validators.required]],
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

  switchEdit(Teacher: any) {
    this.inCreation = false;

    if (this.copyEdit == null && Teacher != null) {
      this.formGroup.reset();
      this.inEdit = true;
      this.copyEdit = Teacher;
      this.formGroup.controls['name'].setValue(this.copyEdit.name);
      this.formGroup.controls['birthDate'].setValue(
        formatDate(this.copyEdit.birthDate, 'yyyy-MM-dd', 'en')
      );
      this.formGroup.controls['salary'].setValue(this.copyEdit.salary);
    } else {
      this.formGroup.reset();
      this.inEdit = false;
      this.copyEdit = null;
    }
  }

  add() {
    this.teachersService
      .add(
        new TeacherAdd(
          this.formGroup.controls['name'].value,
          new Date(this.formGroup.controls['birthDate'].value),
          this.formGroup.controls['salary'].value
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchCreation();
      });
  }

  getAll() {
    this.teachersService.getAll().subscribe((res) => {
      this.allTeachers = res;
    });
  }

  edit() {
    this.teachersService
      .updateById(
        new TeacherUpdate(
          this.copyEdit.id,
          this.formGroup.controls['name'].value,
          new Date(this.formGroup.controls['birthDate'].value),
          this.formGroup.controls['salary'].value
        )
      )
      .subscribe(() => {
        this.getAll();
        this.switchEdit(null);
      });
  }

  delete(Id: number) {
    this.teachersService.deleteById(Id).subscribe(() => {
      this.getAll();
    });
  }
}
