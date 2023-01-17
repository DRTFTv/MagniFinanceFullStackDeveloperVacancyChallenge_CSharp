import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GradeByIdComponent } from './grade-by-id.component';

describe('GradeByIdComponent', () => {
  let component: GradeByIdComponent;
  let fixture: ComponentFixture<GradeByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GradeByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GradeByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
