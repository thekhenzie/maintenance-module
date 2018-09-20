import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateinspectionorderComponent } from './createinspectionorder.component';

describe('CreateinspectionorderComponent', () => {
  let component: CreateinspectionorderComponent;
  let fixture: ComponentFixture<CreateinspectionorderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateinspectionorderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateinspectionorderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
