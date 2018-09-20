import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyAdditionalExposureComponent } from './inspection-checklist-property-additional-exposure.component';

describe('InspectionChecklistPropertyAdditionalExposureComponent', () => {
  let component: InspectionChecklistPropertyAdditionalExposureComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyAdditionalExposureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyAdditionalExposureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyAdditionalExposureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
