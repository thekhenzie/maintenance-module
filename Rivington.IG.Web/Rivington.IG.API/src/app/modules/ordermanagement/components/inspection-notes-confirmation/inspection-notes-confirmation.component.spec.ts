import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionNotesConfirmationComponent } from './inspection-notes-confirmation.component';

describe('InspectionNotesConfirmationComponent', () => {
  let component: InspectionNotesConfirmationComponent;
  let fixture: ComponentFixture<InspectionNotesConfirmationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionNotesConfirmationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionNotesConfirmationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
