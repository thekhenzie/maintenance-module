import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyHighValueInteriorFeatureComponent } from './inspection-checklist-property-high-value-interior-feature.component';

describe('InspectionChecklistPropertyHighValueInteriorFeatureComponent', () => {
  let component: InspectionChecklistPropertyHighValueInteriorFeatureComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyHighValueInteriorFeatureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyHighValueInteriorFeatureComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyHighValueInteriorFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
