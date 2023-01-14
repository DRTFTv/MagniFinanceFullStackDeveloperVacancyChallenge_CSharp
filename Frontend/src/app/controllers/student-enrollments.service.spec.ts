import { TestBed } from '@angular/core/testing';

import { StudentEnrollmentsService } from './student-enrollments.service';

describe('StudentEnrollmentsService', () => {
  let service: StudentEnrollmentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentEnrollmentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
