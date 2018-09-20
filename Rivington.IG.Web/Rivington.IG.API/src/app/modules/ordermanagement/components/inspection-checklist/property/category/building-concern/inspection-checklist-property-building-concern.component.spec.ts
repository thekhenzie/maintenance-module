import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyBuildingConcernComponent } from './inspection-checklist-property-building-concern.component';

describe('InspectionChecklistPropertyBuildingConcernComponent', () => {
  let component: InspectionChecklistPropertyBuildingConcernComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyBuildingConcernComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyBuildingConcernComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyBuildingConcernComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
