import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistPropertyHighValueKitchenComponent } from './inspection-checklist-property-high-value-kitchen.component';

describe('InspectionChecklistPropertyHighValueKitchenComponent', () => {
  let component: InspectionChecklistPropertyHighValueKitchenComponent;
  let fixture: ComponentFixture<InspectionChecklistPropertyHighValueKitchenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistPropertyHighValueKitchenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistPropertyHighValueKitchenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
