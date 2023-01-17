export interface Students {
  id: number;
  name: string;
  birthDate: Date;
}

export interface StudentsHome {
  id: number;
  name: string;
  grades: gradesForDiscipline[];
}

export interface gradesForDiscipline {
  subjectName: string;
  gradeOne: number;
  gradeTwo: number;
  gradeThree: number;
  gradeFour: number;
  gradeAvarege: number;
}

export class StudentAdd {
  name: string;
  birthDate: Date;

  constructor(name: string, birthDate: Date) {
    this.name = name;
    this.birthDate = birthDate;
  }
}

export class StudentUpdate {
  id: number;
  name: string;
  birthDate: Date;

  constructor(id: number, name: string, birthDate: Date) {
    this.id = id;
    this.name = name;
    this.birthDate = birthDate;
  }
}
