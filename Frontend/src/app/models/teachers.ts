export interface Teachers {
  id: number;
  name: string;
  birthDate: Date;
  salary: number;
}

export class TeacherAdd {
  name: string;
  birthDate: Date;
  salary: number;

  constructor(name: string, birthDate: Date, salary: number) {
    this.name = name;
    this.birthDate = birthDate;
    this.salary = salary;
  }
}

export class TeacherUpdate {
  id: number;
  name: string;
  birthDate: Date;
  salary: number;

  constructor(id: number, name: string, birthDate: Date, salary: number) {
    this.id = id;
    this.name = name;
    this.birthDate = birthDate;
    this.salary = salary;
  }
}
