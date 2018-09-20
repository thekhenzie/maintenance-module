import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WildfireAssessmentComponent } from './wildfire-assessment.component';

describe('WildfireAssessmentComponent', () => {
  let component: WildfireAssessmentComponent;
  let fixture: ComponentFixture<WildfireAssessmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WildfireAssessmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WildfireAssessmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
