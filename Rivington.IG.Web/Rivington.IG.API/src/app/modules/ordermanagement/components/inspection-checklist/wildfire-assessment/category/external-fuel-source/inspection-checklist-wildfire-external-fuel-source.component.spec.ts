import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InspectionChecklistWildfireExternalFuelSourceComponent } from './inspection-checklist-wildfire-external-fuel-source.component';

describe('InspectionChecklistWildfireExternalFuelSourceComponent', () => {
  let component: InspectionChecklistWildfireExternalFuelSourceComponent;
  let fixture: ComponentFixture<InspectionChecklistWildfireExternalFuelSourceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InspectionChecklistWildfireExternalFuelSourceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InspectionChecklistWildfireExternalFuelSourceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
