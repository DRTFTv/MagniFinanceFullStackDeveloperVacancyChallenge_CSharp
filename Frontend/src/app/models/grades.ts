export interface Grades {
  id: number;
  gradeOne: number;
  gradeTwo: number;
  gradeThree: number;
  gradeFour: number;
}

export class GradeAdd {
  gradeOne: number;
  gradeTwo: number;
  gradeThree: number;
  gradeFour: number;

  constructor(
    gradeOne: number,
    gradeTwo: number,
    gradeThree: number,
    gradeFour: number
  ) {
    this.gradeOne = gradeOne;
    this.gradeTwo = gradeTwo;
    this.gradeThree = gradeThree;
    this.gradeFour = gradeFour;
  }
}

export class GradeUpdate {
  id: number;
  gradeOne: number;
  gradeTwo: number;
  gradeThree: number;
  gradeFour: number;

  constructor(
    id: number,
    gradeOne: number,
    gradeTwo: number,
    gradeThree: number,
    gradeFour: number
  ) {
    this.id = id;
    this.gradeOne = gradeOne;
    this.gradeTwo = gradeTwo;
    this.gradeThree = gradeThree;
    this.gradeFour = gradeFour;
  }
}
