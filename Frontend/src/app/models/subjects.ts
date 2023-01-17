export interface Subjects {
  id: number;
  name: string;
  courseId: number;
  teacherId: number;
}

export interface SubjectsHome {
  id: number;
  name: string;
  teacherName: string;
  teacherBirthDate: Date;
  teacherSalary: number;
  numberOfStudents: number;
  gradeAvarege: number;
}

export class SubjectAdd {
  name: string;
  courseId: number;
  teacherId: number;

  constructor(name: string, courseId: number, teacherId: number) {
    this.name = name;
    this.courseId = courseId;
    this.teacherId = teacherId;
  }
}

export interface SubjectsGetAll {
  id: number;
  name: string;
  courseId: number;
  courseName: string;
  teacherId: number;
  teacherName: string;
}

export class SubjectUpdate {
  id: number;
  name: string;
  courseId: number;
  teacherId: number;

  constructor(id: number, name: string, courseId: number, teacherId: number) {
    this.id = id;
    this.name = name;
    this.courseId = courseId;
    this.teacherId = teacherId;
  }
}
