export interface Students {
  id: number;
  name: string;
  birthDate: Date;
}

export interface StudentsHome {
  id: number;
  name: string;
  grades: gradeForDiscipline[];
}

export interface gradeForDiscipline {
  subjectName: string;
  gradeOne: number;
  gradeTwo: number;
  gradeThree: number;
  gradeFour: number;
  gradeAvarege: number;
}
