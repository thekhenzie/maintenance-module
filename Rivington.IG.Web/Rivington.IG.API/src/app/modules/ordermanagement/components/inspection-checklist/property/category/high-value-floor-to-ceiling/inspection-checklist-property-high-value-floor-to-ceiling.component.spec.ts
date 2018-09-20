import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyHighValueFloorToCeilingComponent } from './inspection-checklist-property-high-value-floor-to-ceiling.component';

describe('InspectionChecklistPropertyHighValueFloorToCeilingComponent', () => {
  let component: InspectionChecklistPropertyHighValueFloorToCeilingComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyHighValueFloorToCeilingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyHighValueFloorToCeilingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyHighValueFloorToCeilingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
