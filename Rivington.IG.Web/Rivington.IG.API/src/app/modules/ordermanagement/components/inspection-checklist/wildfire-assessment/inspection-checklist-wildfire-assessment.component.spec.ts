import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireAssessmentComponent } from './inspection-checklist-wildfire-assessment.component';

describe('InspectionChecklistWildfireAssessmentComponent', () => {
  let component: InspectionChecklistWildfireAssessmentComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireAssessmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireAssessmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireAssessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
