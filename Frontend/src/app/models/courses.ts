export interface Courses {
  id: number;
  name: string;
}

export interface CoursesHome {
  id: number;
  name: string;
  numberOfTeachers: number;
  numberOfStudents: number;
  gradeAvarege: number;
}

export class CourseAdd {
  name: string;

  constructor(name: string) {
    this.name = name;
  }
}

export class CourseUpdate {
  id: number;
  name: string;

  constructor(id: number, name: string) {
    this.id = id;
    this.name = name;
  }
}
