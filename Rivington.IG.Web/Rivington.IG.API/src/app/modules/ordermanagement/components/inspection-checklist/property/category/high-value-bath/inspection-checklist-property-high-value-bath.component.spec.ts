import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyHighValueBathComponent } from './inspection-checklist-property-high-value-bath.component';

describe('InspectionChecklistPropertyHighValueBathComponent', () => {
  let component: InspectionChecklistPropertyHighValueBathComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyHighValueBathComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyHighValueBathComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyHighValueBathComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
