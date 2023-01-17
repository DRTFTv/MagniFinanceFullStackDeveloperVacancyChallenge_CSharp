export interface Enrollments {
  registrationNumber: number;
  studentId: number;
  subjectId: number;
  gradeId: number;
}

export interface EnrollmentsGetAll {
  registrationNumber: number;
  studentId: number;
  studentName: string;
  grade: gradesForDiscipline;
}

export interface gradesForDiscipline {
  subjectId: number;
  subjectName: string;
  gradeId: number;
  gradeOne: number;
  gradeTwo: number;
  gradeThree: number;
  gradeFour: number;
  gradeAvarege: number;
}

export class EnrollmentAdd {
  studentId: number;
  subjectId: number;

  constructor(studentId: number, subjectId: number) {
    this.studentId = studentId;
    this.subjectId = subjectId;
  }
}

export class EnrollmentUpdate {
  registrationNumber: number;
  studentId: number;
  subjectId: number;
  gradeId: number;

  constructor(
    registrationNumber: number,
    studentId: number,
    subjectId: number,
    gradeId: number
  ) {
    this.registrationNumber = registrationNumber;
    this.studentId = studentId;
    this.subjectId = subjectId;
    this.gradeId = gradeId;
  }
}
