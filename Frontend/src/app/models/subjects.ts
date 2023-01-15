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
